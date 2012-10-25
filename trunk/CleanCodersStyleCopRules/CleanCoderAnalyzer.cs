// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CleanCoderAnalyzer.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   The Clean Coder source analyzer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using CleanCodersStyleCopRules.Rule;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   The Clean Coder source analyzer.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class CleanCoderAnalyzer : SourceAnalyzer
    {
        /// <summary>
        /// Custom rule's type list.
        /// </summary>
        private readonly List<Type> customRuleTypes = new List<Type>();

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CleanCoderAnalyzer" /> class.
        /// </summary>
        public CleanCoderAnalyzer()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            List<Type> types = currentAssembly.GetTypes().Where(type => typeof(ICustomRule).IsAssignableFrom(type)).ToList();

            foreach (Type type in types)
            {
                if (type.FullName.EndsWith("Rule.ICustomRule") == false && type.FullName.EndsWith("Rule.CustomRuleBase") == false)
                {
                    this.customRuleTypes.Add(type);
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets the clean coder analyser setting.
        /// </summary>
        public CleanCoderAnalyserSetting AnalyserSetting { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The entry point to execute the custom rules.
        /// </summary>
        /// <param name="document">
        /// The document, C# source code file.
        /// </param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument csharpDocument = document as CsDocument;

            if (csharpDocument == null || csharpDocument.RootElement == null || csharpDocument.RootElement.Generated)
            {
                return;
            }

            this.AnalyserSetting = new CleanCoderAnalyserSetting(this, document as CsDocument);

            csharpDocument.WalkDocument(this.VisitElement, this.VisitStatement, this.VisitExpression, this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delegate called when an element is visited.
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
        /// True if all visited elements are valid, False otherwise.
        /// </returns>
        private bool VisitElement(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
        {
            if (element.Generated)
            {
                return true;
            }

            bool returnFlag = true;

            foreach (Type customRuleType in this.customRuleTypes)
            {
                ICustomRule customRule = (ICustomRule)Activator.CreateInstance(customRuleType);

                if (customRule.ElementTypes.Contains(element.ElementType))
                {
                    returnFlag = customRule.ValidateElement(element, parentElement, context);
                }
            }

            return returnFlag;
        }

        /// <summary>
        /// The visit expression.
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
        private bool VisitExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            bool returnFlag = true;

            foreach (Type customRuleType in this.customRuleTypes)
            {
                ICustomRule customRule = (ICustomRule)Activator.CreateInstance(customRuleType);

                if (customRule.ExpressionTypes.Contains(expression.ExpressionType))
                {
                    returnFlag = customRule.ValidateExpression(expression, parentExpression, parentStatement, parentElement, context);
                }
            }

            return returnFlag;
        }

        /// <summary>
        /// The visit statement.
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
        private bool VisitStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, CleanCoderAnalyzer context)
        {
            bool returnFlag = true;

            foreach (Type customRuleType in this.customRuleTypes)
            {
                ICustomRule customRule = (ICustomRule)Activator.CreateInstance(customRuleType);

                if (customRule.StatementTypes.Contains(statement.StatementType))
                {
                    returnFlag = customRule.ValidateStatement(statement, parentExpression, parentStatement, parentElement, context);
                }
            }

            return returnFlag;
        }

        #endregion
    }
}