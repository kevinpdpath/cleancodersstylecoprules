// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatementVisitorContainer.cs" company="None, it's free for all.">
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
    ///   Structure for rules to be checked on the statement visitor delegate.
    /// </summary>
    internal struct StatementVisitorContainer
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the list of type of statement that apply to the rule.
        /// </summary>
        public List<StatementType> StatementTypes { get; set; }

        /// <summary>
        ///   Gets or sets the metthod callback for the rule.
        /// </summary>
        public CodeWalkerStatementVisitor<CleanCoderAnalyzer> MethodCallback { get; set; }

        #endregion
    }
}