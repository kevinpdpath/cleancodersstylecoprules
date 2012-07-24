// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionHasNegativeConditional.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if an expression has negative conditional.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if an expression has negative conditional.
    /// </summary>
    public static class ExpressionHasNegativeConditional
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
        /// Validate if an expression has negative conditional.
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
        public static bool Validate(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(parentStatement, "parentStatement");
            Param.AssertNotNull(context, "context");

            if (expression is UnaryExpression && ((expression as UnaryExpression).OperatorType == UnaryExpression.Operator.Not))
            {
                context.AddViolation(parentElement, expression.LineNumber, RuleName, expression.Text);
            }

            return true;
        }

        #endregion
    }
}