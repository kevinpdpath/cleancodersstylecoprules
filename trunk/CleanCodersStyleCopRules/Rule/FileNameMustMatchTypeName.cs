// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileNameMustMatchTypeName.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a the file name matches the type name it contains.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if a the file name matches the type name it contains.
    /// </summary>
    public static class FileNameMustMatchTypeName
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
        /// Validate if a the file name matches the type name it contains.
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

            if (element.AccessModifier == AccessModifierType.Private || parentElement.ElementType != ElementType.Namespace)
            {
                return true;
            }

            string fileName = Path.GetFileNameWithoutExtension(element.Document.SourceCode.Path);

            if (string.IsNullOrEmpty(fileName))
            {
                return true;
            }

            string typeName = Utility.TrimGenericType(element.Declaration.Name);

            CsElement firstChild = Utility.GetFirstChildOfElement(parentElement, new List<ElementType> { ElementType.UsingDirective });

            if (firstChild == null)
            {
                return true;
            }

            if (firstChild.Declaration.Name != element.Declaration.Name)
            {
                return true;
            }

            if (Utility.IsDeclarationPartial(element.Declaration))
            {
                if (fileName.Contains(typeName) == false)
                {
                    context.AddViolation(element, element.LineNumber, RuleName, fileName, typeName);
                }

                return true;
            }

            if (fileName != typeName)
            {
                context.AddViolation(element, element.LineNumber, RuleName, fileName, typeName);
            }

            return true;
        }

        #endregion
    }
}