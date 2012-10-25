// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameHasUnderscore.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if a variable has an underscore in it name.
    /// </summary>
    public class VariableNameHasUnderscore : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNameHasUnderscore"/> class.
        /// </summary>
        public VariableNameHasUnderscore()
        {
            this.ElementTypes.Add(ElementType.Method);
            this.ElementTypes.Add(ElementType.Constructor);

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
        /// Validate if the parameters of a method or constructor contain an underscore in their name with an element.
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
        public override bool ValidateElement(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(context, "context");

            if (element.ElementType == ElementType.Method)
            {
                this.ProcessParameter(element, ((Method)element).Parameters.ToList(), context);
            }
            else if (element.ElementType == ElementType.Constructor)
            {
                this.ProcessParameter(element, ((Constructor)element).Parameters.ToList(), context);
            }

            return true;
        }

        /// <summary>
        /// Validate if the variable is not plural with an expression.
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

            this.ProcessVariableName(parentElement, variableDeclaratorExpression.Identifier.Text, expression.Location.LineNumber, context);

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Process the parameter of a method or a constructor.
        /// </summary>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="parameters">
        /// The parameters. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        private void ProcessParameter(CsElement element, IEnumerable<Parameter> parameters, CleanCoderAnalyzer context)
        {
            foreach (Parameter parameter in parameters)
            {
                this.ProcessVariableName(element, parameter.Name, parameter.LineNumber, context);
            }
        }

        /// <summary>
        /// Validate if a variable has an underscore in its name.
        /// </summary>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="variableName">
        /// The variable name. 
        /// </param>
        /// <param name="lineNumber">
        /// The line number where the variable apperas. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        private void ProcessVariableName(CsElement element, string variableName, int lineNumber, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(variableName, "variableName");
            Param.AssertNotNull(lineNumber, "lineNumber");
            Param.AssertNotNull(context, "context");

            int numerOfUnderscore = variableName.Count(c => c == '_');

            if (numerOfUnderscore > 0)
            {
                context.AddViolation(element, lineNumber, this.RuleName, variableName, numerOfUnderscore);
            }
        }

        #endregion
    }
}