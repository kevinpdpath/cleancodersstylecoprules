// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodHasTooManyArgument.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if a method contains too many arguments.
    /// </summary>
    public class MethodHasTooManyArgument : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodHasTooManyArgument"/> class.
        /// </summary>
        public MethodHasTooManyArgument()
        {
            this.ElementTypes.Add(ElementType.Method);
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
        /// Validate if a method contains too many arguments with an element.
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

            Method method = element as Method;

            if (method == null)
            {
                return true;
            }

            if (Utility.HasDllImportAttribute(method))
            {
                return true;
            }

            int actualNumberOfParameters = method.Parameters.Count;

            if (actualNumberOfParameters > (int)context.AnalyserSetting[RuleSettingName])
            {
                context.AddViolation(method, method.LineNumber, this.RuleName, method.Declaration.Name, actualNumberOfParameters, context.AnalyserSetting[RuleSettingName]);
            }

            return true;
        }

        #endregion
    }
}