// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TooManyComment.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if comments are missused.
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
    ///   StyleCop custom rule that validates if comments are missused.
    /// </summary>
    public static class TooManyComment
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
        /// Validate if comments are missused.
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

            int firstLineNumber = element.LineNumber;

            CsToken lastToken = element.Tokens.LastOrDefault();

            if (lastToken == null)
            {
                return true;
            }

            int numberOfLinesInMethod = lastToken.LineNumber - firstLineNumber;

            int numberOfLineOfComment = element.Tokens.Count(token => token.CsTokenType == CsTokenType.SingleLineComment);

            if (numberOfLineOfComment == 0)
            {
                return true;
            }

            decimal ratio = (numberOfLineOfComment * 100) / numberOfLinesInMethod;

            decimal percentComment = Math.Round(ratio, 1);

            if (percentComment > (int)context.AnalyserSetting[RuleSettingName])
            {
                context.AddViolation(element, element.LineNumber, RuleName, element.Declaration.Name, percentComment, context.AnalyserSetting[RuleSettingName]);
            }

            return true;
        }

        #endregion
    }
}