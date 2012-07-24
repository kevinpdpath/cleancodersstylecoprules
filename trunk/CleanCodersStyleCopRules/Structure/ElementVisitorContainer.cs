// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementVisitorContainer.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Structure for rules to be checked on the element visitor delegate.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Structure
{
    using System.Collections.Generic;

    using StyleCop.CSharp;

    /// <summary>
    ///   Structure for rules to be checked on the element visitor delegate.
    /// </summary>
    internal struct ElementVisitorContainer
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the list of type of element that apply to the rule.
        /// </summary>
        public List<ElementType> ElementTypes { get; set; }

        /// <summary>
        ///   Gets or sets the metthod callback for the rule.
        /// </summary>
        public CodeWalkerElementVisitor<CleanCoderAnalyzer> MethodCallback { get; set; }

        #endregion
    }
}