// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableTypeIsNotExplicit.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if a variable is not explicitly defined.
    /// </summary>
    public class VariableTypeIsNotExplicit : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableTypeIsNotExplicit"/> class.
        /// </summary>
        public VariableTypeIsNotExplicit()
        {
            this.ExpressionTypes.Add(ExpressionType.VariableDeclarator);
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
        /// Validate if a variable type not explicitly defined with an expression.
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
        /// True if all visited expressions are valid, False otherwise. 
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate.")]
        public override bool ValidateExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            if (expression.ExpressionType != ExpressionType.VariableDeclarator)
            {
                return true;
            }

            VariableDeclaratorExpression variableDeclaratorExpression = expression as VariableDeclaratorExpression;

            if (variableDeclaratorExpression == null)
            {
                return true;
            }

            if (variableDeclaratorExpression.ParentVariable.Type.Text.Equals("var"))
            {
                context.AddViolation(parentElement, expression.Location.LineNumber, this.RuleName, variableDeclaratorExpression.Identifier.Text);
            }

            return true;
        }

        #endregion
    }
}