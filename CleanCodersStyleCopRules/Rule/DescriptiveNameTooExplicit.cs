// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DescriptiveNameTooExplicit.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if the name is too explicit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if the name is too explicit.
    /// </summary>
    public static class DescriptiveNameTooExplicit
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
        /// Validate if the name is too explicit.
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

            string compareTo = string.Empty;

            if (element.ElementType == ElementType.Enum || element.ElementType == ElementType.EnumItem)
            {
                compareTo = "enum";
            }
            else if (element.ElementType == ElementType.Class)
            {
                compareTo = "class";
            }
            else if (element.ElementType == ElementType.Interface)
            {
                compareTo = "interface";
            }
            else if (element.ElementType == ElementType.Method)
            {
                compareTo = "method";
            }
            else if (element.ElementType == ElementType.Struct)
            {
                compareTo = "struct";
            }
            else if (element.ElementType == ElementType.Field)
            {
                compareTo = "field";
            }
            else if (element.ElementType == ElementType.Property)
            {
                compareTo = "property";
            }

            if (element.Declaration.Name.ToLower().Contains(compareTo))
            {
                context.AddViolation(element, element.LineNumber, RuleName, element.Declaration.Name, compareTo);
            }

            return true;
        }

        #endregion
    }
}