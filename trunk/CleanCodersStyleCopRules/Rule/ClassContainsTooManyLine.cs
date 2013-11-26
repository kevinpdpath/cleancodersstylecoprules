// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassContainsTooManyLine.cs" company="None, it's free for all.">
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
    /// StyleCop custom rule that validates if a class contains too many lines.
    /// </summary>
    [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0309:DescriptiveNameTooExplicit", Justification = "It's for a test.")]
    public class ClassContainsTooManyLine : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassContainsTooManyLine"/> class.
        /// </summary>
        public ClassContainsTooManyLine()
        {
            this.ElementTypes.Add(ElementType.Class);
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
        /// Validate if a class contains too many lines with an element.
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

            int numberOfLinesInClass = 0;

            for (int lineOffset = element.Location.StartPoint.LineNumber - 1; lineOffset < element.Location.EndPoint.LineNumber; lineOffset++)
            {
                string currentLine = lines[lineOffset].Trim();

                if (string.IsNullOrEmpty(currentLine) == false)
                {
                    numberOfLinesInClass++;
                }
            }

            if (numberOfLinesInClass > (int)context.AnalyserSetting[RuleSettingName])
            {
                context.AddViolation(element, element.LineNumber, this.RuleName, element.Declaration.Name, numberOfLinesInClass, context.AnalyserSetting[RuleSettingName]);
            }

            return true;
        }

        #endregion
    }
}