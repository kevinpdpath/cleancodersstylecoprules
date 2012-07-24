// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionVisitorContainer.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Structure for rules to be checked on the expression visitor delegate.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Structure
{
    using System.Collections.Generic;

    using StyleCop.CSharp;

    /// <summary>
    ///   Structure for rules to be checked on the expression visitor delegate.
    /// </summary>
    internal struct ExpressionVisitorContainer
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the list of type of expression that apply to the rule.
        /// </summary>
        public List<ExpressionType> ExpressionTypes { get; set; }

        /// <summary>
        ///   Gets or sets the metthod callback for the rule.
        /// </summary>
        public CodeWalkerExpressionVisitor<CleanCoderAnalyzer> MethodCallback { get; set; }

        #endregion
    }
}