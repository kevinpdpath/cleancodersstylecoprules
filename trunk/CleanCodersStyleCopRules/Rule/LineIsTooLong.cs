// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineIsTooLong.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if a code line, including comment, is too long.
    /// </summary>
    public class LineIsTooLong : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LineIsTooLong"/> class.
        /// </summary>
        public LineIsTooLong()
        {
            this.ElementTypes.Add(ElementType.Class);
            this.ElementTypes.Add(ElementType.Enum);
            this.ElementTypes.Add(ElementType.Interface);
            this.ElementTypes.Add(ElementType.Struct);
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
        /// Validate if a code line, including comment, is too long with an element.
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

            List<string> lines = Utility.SplitSourceCodeInLine(element.Document.SourceCode);

            for (int lineOffset = element.Location.StartPoint.LineNumber; lineOffset < element.Location.EndPoint.LineNumber; lineOffset++)
            {
                int currentLineNumber = lineOffset + 1;

                string currentLine = lines[lineOffset];

                if (currentLine.Length > (int)context.AnalyserSetting[RuleSettingName])
                {
                    context.AddViolation(element, currentLineNumber, this.RuleName, currentLine.Length, context.AnalyserSetting[RuleSettingName]);
                }
            }

            return true;
        }

        #endregion
    }
}