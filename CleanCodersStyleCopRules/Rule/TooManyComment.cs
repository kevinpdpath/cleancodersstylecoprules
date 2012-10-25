// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TooManyComment.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if comments are missused.
    /// </summary>
    public class TooManyComment : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyComment"/> class.
        /// </summary>
        public TooManyComment()
        {
            this.ElementTypes.Add(ElementType.Method);
            this.ElementTypes.Add(ElementType.Constructor);
            this.ElementTypes.Add(ElementType.Property);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the rule setting name.
        /// </summary>
        public static new string RuleSettingName
        {
            get
            {
                return MethodBase.GetCurrentMethod().ReflectedType.Name + "Value";
            }
        }

        /// <summary>
        /// Gets the rule name.
        /// </summary>
        public override string RuleName
        {
            get
            {
                return MethodBase.GetCurrentMethod().ReflectedType.Name;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Validate if comments are missused element.
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
        public override bool ValidateElement(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
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

            IEnumerable<CsToken> commentTokens = from t in element.Tokens where t.CsTokenType == CsTokenType.SingleLineComment select t;

            Regex acceptableComment = new Regex("^// TODO|// HACK|// UNDONE");

            int numberOfLineOfComment = 0;

            foreach (CsToken commentToken in commentTokens)
            {
                if (acceptableComment.IsMatch(commentToken.Text))
                {
                    continue;
                }

                numberOfLineOfComment++;
            }

            if (numberOfLineOfComment == 0)
            {
                return true;
            }

            decimal ratio = (numberOfLineOfComment * 100) / (decimal)numberOfLinesInMethod;

            decimal percentComment = Math.Round(ratio, 1);

            if (percentComment > (int)context.AnalyserSetting[RuleSettingName])
            {
                context.AddViolation(element, element.LineNumber, this.RuleName, element.Declaration.Name, percentComment, context.AnalyserSetting[RuleSettingName]);
            }

            return true;
        }

        #endregion
    }
}