// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomRule.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using StyleCop.CSharp;

    /// <summary>
    /// Interface for all custom rules.
    /// </summary>
    public interface ICustomRule
    {
        #region Public Properties

        /// <summary>
        /// Gets the element types.
        /// </summary>
        List<ElementType> ElementTypes { get; }

        /// <summary>
        /// Gets the expression types.
        /// </summary>
        List<ExpressionType> ExpressionTypes { get; }

        /// <summary>
        /// Gets the rule name.
        /// </summary>
        string RuleName { get; }

        /// <summary>
        /// Gets the rule setting name.
        /// </summary>
        string RuleSettingName { get; }

        /// <summary>
        /// Gets the statement types.
        /// </summary>
        List<StatementType> StatementTypes { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Validate an element.
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
        bool ValidateElement(CsElement element, CsElement parentElement, CleanCoderAnalyzer context);

        /// <summary>
        /// Validate with an expression.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement.
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
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitExpression.")]
        bool ValidateExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context);

        /// <summary>
        /// Validate with a statement.
        /// </summary>
        /// <param name="statement">
        /// The statement.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement.
        /// </param>
        /// <param name="parentElement">
        /// The parent element.
        /// </param>
        /// <param name="context">
        /// The context, this class.
        /// </param>
        /// <returns>
        /// True if all visited statements are valid, False otherwise.
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitStatement.")]
        bool ValidateStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context);

        #endregion
    }
}