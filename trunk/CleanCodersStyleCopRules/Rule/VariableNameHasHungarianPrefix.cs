// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameHasHungarianPrefix.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a variable has an hungarian prefix.
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
    ///   StyleCop custom rule that validates if a variable has an hungarian prefix.
    /// </summary>
    public static class VariableNameHasHungarianPrefix
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
        /// Validate if the the variables of a method or a field has an hungarian prefix.
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
                ProcessVariableName(element, element.Declaration.Name, element.LineNumber, context);
            }
            else if (element.ElementType == ElementType.Method)
            {
                foreach (Variable variable in element.Variables.ToList())
                {
                    ProcessVariableName(element, variable.Name, variable.Location.LineNumber, context);
                }
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validate if a variable has an hungarian prefix.
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

            string[] variableParts = Utility.SplitStringAtUpperCaseLetter(variableName);

            if (variableParts.Length <= 1)
            {
                return;
            }

            List<string> invalidPrefix = (List<string>)context.AnalyserSetting[RuleSettingName];

            if (invalidPrefix.Contains(variableParts[0]))
            {
                context.AddViolation(element, lineNumber, RuleName, variableName, variableParts[0]);
            }
        }

        #endregion
    }
}