// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameIsNotPlural.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a variable name is not plural.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if a variable name is not plural.
    /// </summary>
    public static class VariableNameIsNotPlural
    {
        #region Public Properties

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
        /// Validate if the parameters of a method or constructor are not plural with an element.
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

            if (element.ElementType == ElementType.Method)
            {
                ProcessParameter(element, ((Method)element).Parameters.ToList(), context);
            }
            else if (element.ElementType == ElementType.Constructor)
            {
                ProcessParameter(element, ((Constructor)element).Parameters.ToList(), context);
            }

            return true;
        }

        /// <summary>
        /// Validate if a variable name is not plural with an expression.
        /// </summary>
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

            ProcessVariableName(parentElement, variableDeclaratorExpression.Identifier.Text, variableDeclaratorExpression.ParentVariable.Type.Text, expression.Location.LineNumber, context);

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Process the parameter of a method or a constructor.
        /// </summary>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="parameters">
        /// The parameters. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        private static void ProcessParameter(CsElement element, IEnumerable<Parameter> parameters, CleanCoderAnalyzer context)
        {
            foreach (Parameter parameter in parameters)
            {
                ProcessVariableName(element, parameter.Name, parameter.Type.Text, parameter.LineNumber, context);
            }
        }

        /// <summary>
        /// Validate if a variable name is not plural.
        /// </summary>
        /// <remarks>
        /// In English, we say a plural ends with S, and in French, it could be S or X.
        /// </remarks>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="variableName">
        /// The variable name. 
        /// </param>
        /// <param name="variableTypeDefinition">
        /// The variable type definition. 
        /// </param>
        /// <param name="lineNumber">
        /// The line number where the variable apperas. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        private static void ProcessVariableName(CsElement element, string variableName, string variableTypeDefinition, int lineNumber, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(variableName, "variableName");
            Param.AssertNotNull(lineNumber, "lineNumber");
            Param.AssertNotNull(context, "context");

            if (Utility.IsSomeKindOfMatrix(variableTypeDefinition) && variableName.ToLower().EndsWith("s") == false && variableName.ToLower().EndsWith("x") == false)
            {
                context.AddViolation(element, lineNumber, RuleName, variableName);
            }
        }

        #endregion
    }
}