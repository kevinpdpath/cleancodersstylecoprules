// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantIsNotPascalCase.cs" company="">
//   
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a constant is not following the PascalCase convention.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if a constant is not following the PascalCase convention.
    /// </summary>
    public static class ConstantIsNotPascalCase
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
        /// Validate if a constant is not following the PascalCase convention.
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
        public static bool Validate(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(context, "context");

            if (element.ElementType == ElementType.Field)
            {
                Field field = element as Field;

                if (field == null || field.Const == false)
                {
                    return true;
                }

                ProcessName(element, field.Declaration.Name, field.LineNumber, context);
            }
            else if (element.ElementType == ElementType.Method)
            {
                ParseMethod(element as Method, context);
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse method to validate the constants it may contain.
        /// </summary>
        /// <param name="method">
        /// The method. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0309:DescriptiveNameTooExplicit", Justification = "It's for a test.")]
        private static void ParseMethod(Method method, CleanCoderAnalyzer context)
        {
            foreach (Variable variable in method.Variables.ToList())
            {
                Statement parentStatement = variable.FindParentStatement();

                if (parentStatement == null)
                {
                    continue;
                }

                CsToken firstToken = parentStatement.Tokens.FirstOrDefault();

                if (firstToken == null || firstToken.Text.Equals("const") == false)
                {
                    continue;
                }

                ProcessName(method, variable.Name, variable.LineNumber, context);
            }
        }

        /// <summary>
        /// Validate if a constant is not following the PascalCase convention.
        /// </summary>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="name">
        /// The variable name. 
        /// </param>
        /// <param name="lineNumber">
        /// The line number where the variable apperas. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        private static void ProcessName(CsElement element, string name, int lineNumber, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(name, "name");
            Param.AssertNotNull(lineNumber, "lineNumber");
            Param.AssertNotNull(context, "context");

            if (name.Equals(name.ToUpper(), StringComparison.InvariantCulture))
            {
                context.AddViolation(element, lineNumber, RuleName, name);
            }
        }

        #endregion
    }
}