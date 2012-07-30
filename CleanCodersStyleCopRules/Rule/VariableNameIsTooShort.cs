// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameIsTooShort.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a variable name is too short.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if a variable name is too short.
    /// </summary>
    public static class VariableNameIsTooShort
    {
        #region Public Properties

        /// <summary>
        /// Gets the rule setting name.
        /// </summary>
        public static string RuleSettingName
        {
            get
            {
                return MethodBase.GetCurrentMethod().ReflectedType.Name + "Value";
            }
        }

        /// <summary>
        ///   Gets the rule name.
        /// </summary>
        public static string RuleName
        {
            get
            {
                return MethodBase.GetCurrentMethod().ReflectedType.Name;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Validate if the the variables of a method or a field is too short  with an element.
        /// </summary>
        /// <param name="element">
        /// The current element. 
        /// </param>
        /// <param name="parentElement">
        /// The parent element. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        /// <returns>
        /// Returns true to continue, false to stop visiting the elements in the code document. 
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        public static bool ValidateElement(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(context, "context");

            foreach (Constructor constructor in element.ChildCodeElements.OfType<Constructor>().ToList())
            {
                ParseConstructor(constructor, context);
            }

            foreach (Method method in element.ChildCodeElements.OfType<Method>().ToList())
            {
                ParseMethod(method, context);
            }

            foreach (Struct structObject in element.ChildCodeElements.OfType<Struct>().ToList())
            {
                ParseStruct(structObject, context);
            }

            foreach (Enum enumObject in element.ChildCodeElements.OfType<Enum>().ToList())
            {
                ParseEnum(enumObject, context);
            }

            if (element.ElementType == ElementType.Method)
            {
                Method method = element as Method;

                if (method == null)
                {
                    return true;
                }

                foreach (Parameter parameter in method.Parameters.ToList())
                {
                    ProcessVariableName(element, parameter.Name, parameter.LineNumber, context);
                }
            }

            return true;
        }

        /// <summary>
        /// Validate if a variable name is too short with an expression.
        /// </summary>
        /// <remarks>
        /// The variable declarator catches all 
        /// </remarks>
        /// <param name="expression">
        /// The expression. 
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression. 
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement. 
        /// </param>
        /// <param name="parentElement">
        /// The parent element. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        /// <returns>
        /// True if all visited expressions are valid, False otherwise. 
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate.")]
        public static bool ValidateExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            if (expression.ExpressionType != ExpressionType.VariableDeclarator)
            {
                return true;
            }

            VariableDeclaratorExpression variableDeclaratorExpression = expression as VariableDeclaratorExpression;

            if (variableDeclaratorExpression == null)
            {
                return true;
            }

            if (parentStatement.StatementType == StatementType.For)
            {
                if (parentStatement.Location.LineSpan < 10)
                {
                    return true;
                }
            }

            ProcessVariableName(parentElement, variableDeclaratorExpression.Identifier.Text, expression.Location.LineNumber, context);

             return true;
        }

        /// <summary>
        /// Validate if a variable name is too short.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="variableName">
        /// The variable name. 
        /// </param>
        /// <param name="lineNumber">
        /// The line number where the variable apperas. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        private static void ProcessVariableName(CsElement element, string variableName, int lineNumber, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(variableName, "variableName");
            Param.AssertNotNull(lineNumber, "lineNumber");
            Param.AssertNotNull(context, "context");

            if (variableName.Length < (int)context.AnalyserSetting[RuleSettingName])
            {
                context.AddViolation(element, lineNumber, RuleName, variableName, variableName.Length, context.AnalyserSetting[RuleSettingName]);
            }
        }

        #endregion
    }
}