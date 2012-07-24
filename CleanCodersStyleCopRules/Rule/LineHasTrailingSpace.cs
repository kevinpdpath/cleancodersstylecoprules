// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineHasTrailingSpace.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a code line, excluding comment, is ended with a space.
// </summary>
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
    ///   StyleCop custom rule that validates if a code line, excluding comment, is ended with a space.
    /// </summary>
    public static class LineHasTrailingSpace
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
        /// Validate if a code line, excluding comment, is ended with a space.
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

            DocumentRoot documentRoot = element as DocumentRoot;

            if (documentRoot == null)
            {
                return true;
            }

            List<string> lines = Utility.SplitSourceCodeInLine(documentRoot.Document.SourceCode);

            for (int i = 0; i < lines.Count; i++)
            {
                int currentLineNumber = i + 1;

                string currentLine = lines[i];

                if (currentLine.Trim().StartsWith("//"))
                {
                    continue;
                }

                int trimmedLength = currentLine.TrimEnd(new[] { ' ' }).Length;

                if (currentLine.Trim().EndsWith(","))
                {
                    // The + 1 here is to allow for a single trailing space, because when we have multiple line statements, they always end up with 1 trailing space.
                    trimmedLength += 1;
                }

                if (currentLine.Length > trimmedLength)
                {
                    context.AddViolation(documentRoot, currentLineNumber, RuleName, currentLine.Length);
                }
            }

            return true;
        }

        #endregion
    }
}