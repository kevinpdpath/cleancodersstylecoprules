// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlockStatementMustNotBeEmpty.cs" company="None, it's free for all.">
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
    /// StyleCop custom rule that validates if a block statement is empty.
    /// </summary>
    public class BlockStatementMustNotBeEmpty : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStatementMustNotBeEmpty"/> class.
        /// </summary>
        public BlockStatementMustNotBeEmpty()
        {
            this.StatementTypes.Add(StatementType.Block);
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
        /// Validate if a block statement is empty with a statement.
        /// </summary>
        /// <param name="statement">
        /// The current element. 
        /// </param>
        /// <param name="parentExpression">
        /// The parent Expression. 
        /// </param>
        /// <param name="parentStatement">
        /// The parent Statement. 
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
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitStatement.")]
        public override bool ValidateStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(statement, "statement");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.AssertNotNull(context, "context");

            if (statement.ChildStatements.Count == 0)
            {
                context.AddViolation(parentElement, statement.LineNumber, this.RuleName);
            }

            return true;
        }

        #endregion
    }
}