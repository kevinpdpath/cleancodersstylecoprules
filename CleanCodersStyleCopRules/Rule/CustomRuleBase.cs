// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomRuleBase.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using StyleCop.CSharp;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomRuleBase : ICustomRule
    {
        #region Fields

        /// <summary>
        /// The element types supported.
        /// </summary>
        private readonly List<ElementType> elementTypes = new List<ElementType>();

        /// <summary>
        /// The expression types supported.
        /// </summary>
        private readonly List<ExpressionType> expressionTypes = new List<ExpressionType>();

        /// <summary>
        /// The statement types supported.
        /// </summary>
        private readonly List<StatementType> statementTypes = new List<StatementType>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the rule setting name.
        /// </summary>
        public string RuleSettingName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the element types.
        /// </summary>
        public List<ElementType> ElementTypes
        {
            get
            {
                return this.elementTypes;
            }
        }

        /// <summary>
        /// Gets the expression types.
        /// </summary>
        public List<ExpressionType> ExpressionTypes
        {
            get
            {
                return this.expressionTypes;
            }
        }

        /// <summary>
        /// Gets the rule name.
        /// </summary>
        public virtual string RuleName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the statement types.
        /// </summary>
        public List<StatementType> StatementTypes
        {
            get
            {
                return this.statementTypes;
            }
        }

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
        public virtual bool ValidateElement(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
        {
            return true;
        }

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
        public virtual bool ValidateExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            return true;
        }

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
        public virtual bool ValidateStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            return true;
        }

        #endregion
    }
}