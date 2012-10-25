// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DescriptiveNameTooExplicit.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if the name is too explicit.
    /// </summary>
    public class DescriptiveNameTooExplicit : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptiveNameTooExplicit"/> class.
        /// </summary>
        public DescriptiveNameTooExplicit()
        {
            this.ElementTypes.Add(ElementType.Enum);
            this.ElementTypes.Add(ElementType.EnumItem);
            this.ElementTypes.Add(ElementType.Class);
            this.ElementTypes.Add(ElementType.Interface);
            this.ElementTypes.Add(ElementType.Method);
            this.ElementTypes.Add(ElementType.Struct);
            this.ElementTypes.Add(ElementType.Field);
            this.ElementTypes.Add(ElementType.Property);
        }

        #endregion

        #region Public Properties

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
        /// Validate if the name is too explicit with an element.
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

            string compareTo = element.ElementType.ToString().ToLower();

            if (element.Declaration.Name.ToLower().Contains(compareTo))
            {
                context.AddViolation(element, element.LineNumber, this.RuleName, element.Declaration.Name, compareTo);
            }

            return true;
        }

        #endregion
    }
}