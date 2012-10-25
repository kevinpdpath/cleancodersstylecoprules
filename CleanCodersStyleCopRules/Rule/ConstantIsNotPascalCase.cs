// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantIsNotPascalCase.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if a constant is not following the PascalCase convention.
    /// </summary>
    public class ConstantIsNotPascalCase : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantIsNotPascalCase"/> class.
        /// </summary>
        public ConstantIsNotPascalCase()
        {
            this.StatementTypes.Add(StatementType.VariableDeclaration);
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
        /// Validate if a constant is not following the PascalCase convention with a statement.
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
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate.")]
        public override bool ValidateStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            if (statement.StatementType != StatementType.VariableDeclaration)
            {
                return true;
            }

            VariableDeclarationStatement variableDeclarationStatement = statement as VariableDeclarationStatement;

            if (variableDeclarationStatement == null)
            {
                return true;
            }

            if (variableDeclarationStatement.Constant)
            {
                VariableDeclaratorExpression variableDeclaratorExpression = variableDeclarationStatement.Declarators.First();

                if (variableDeclaratorExpression == null)
                {
                    return true;
                }

                this.ProcessVariableName(parentElement, variableDeclaratorExpression.Identifier.Text, statement.LineNumber, context);
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validate if a constant is not following the PascalCase convention.
        /// </summary>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="name">
        /// The variable name. 
        /// </param>
        /// <param name="lineNumber">
        /// The line number where the variable apperas. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        private void ProcessVariableName(CsElement element, string name, int lineNumber, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(name, "name");
            Param.AssertNotNull(lineNumber, "lineNumber");
            Param.AssertNotNull(context, "context");

            if (name.Equals(name.ToUpper(), StringComparison.InvariantCulture))
            {
                context.AddViolation(element, lineNumber, this.RuleName, name);
            }
        }

        #endregion
    }
}