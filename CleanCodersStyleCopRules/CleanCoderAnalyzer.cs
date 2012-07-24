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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using CleanCodersStyleCopRules.Rule;
    using CleanCodersStyleCopRules.Structure;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   The Clean Coder source analyzer.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class CleanCoderAnalyzer : SourceAnalyzer
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CleanCoderAnalyzer" /> class.
        /// </summary>
        public CleanCoderAnalyzer()
        {
            this.ElementVisitorRegistry = new List<ElementVisitorContainer>();

            this.RegisterElementVisitorRule();

            this.ExpressionVisitorRegistry = new List<ExpressionVisitorContainer>();

            this.RegisterExpressionVisitorRule();

            this.StatementVisitorRegistry = new List<StatementVisitorContainer>();

            this.RegisterStatementVisitorRule();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets the clean coder analyser setting.
        /// </summary>
        public CleanCoderAnalyserSetting AnalyserSetting { get; set; }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the list of element visitor rules.
        /// </summary>
        private List<ElementVisitorContainer> ElementVisitorRegistry { get; set; }

        /// <summary>
        ///   Gets or sets the list of expression visitor rules.
        /// </summary>
        private List<ExpressionVisitorContainer> ExpressionVisitorRegistry { get; set; }

        /// <summary>
        ///   Gets or sets the list of statement visitor rules.
        /// </summary>
        private List<StatementVisitorContainer> StatementVisitorRegistry { get; set; }

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

            if (csharpDocument != null)
            {
                this.AnalyserSetting = new CleanCoderAnalyserSetting(this, document as CsDocument);

                csharpDocument.WalkDocument(this.VisitElement, this.VisitStatement, this.VisitExpression, this);
            }
        }

        /// <summary>
        ///   Registers the rules that are meant to be executed by the element visitor delegate.
        /// </summary>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0034:MethodContainsTooManyLine", Justification = "No choice, all rules must be registered.")]
        public void RegisterElementVisitorRule()
        {
            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Class }, MethodCallback = ClassContainsTooManyLine.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Class }, MethodCallback = ClassContainsTooManyMethod.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Class }, MethodCallback = ClassNameHasTooManyWord.Validate });

            this.ElementVisitorRegistry.Add(
                new ElementVisitorContainer
                    {
                       ElementTypes = new List<ElementType> { ElementType.Class, ElementType.Struct, ElementType.Interface }, MethodCallback = FileNameMustMatchTypeName.Validate
                    });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = MethodContainsTooManyLine.Validate });

            this.ElementVisitorRegistry.Add(
                new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method, ElementType.Field }, MethodCallback = VariableNameHasHungarianPrefix.Validate });

            this.ElementVisitorRegistry.Add(
                new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method, ElementType.Field }, MethodCallback = VariableNameHasUnderscore.Validate });

            this.ElementVisitorRegistry.Add(
                new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method, ElementType.Field }, MethodCallback = VariableNameIsTooShort.Validate });

            this.ElementVisitorRegistry.Add(
                new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method, ElementType.Field }, MethodCallback = VariableNameIsNotPlural.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = VariableTypeIsNotExplicit.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = MethodHasTooManyArgument.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = MethodHasOutputParameter.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = MethodHasBooleanParameter.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = MethodContainsSwitchStatement.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = MethodContainsGotoStatement.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Root }, MethodCallback = LineIsTooLong.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Root }, MethodCallback = LineContainsTrainWreck.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Root }, MethodCallback = LineHasTrailingSpace.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Property }, MethodCallback = PropertyContainsTooManyLine.Validate });

            this.ElementVisitorRegistry.Add(
                new ElementVisitorContainer
                    {
                        ElementTypes =
                            new List<ElementType>
                                {
                                    ElementType.Namespace,
                                    ElementType.Class,
                                    ElementType.Enum,
                                    ElementType.Interface,
                                    ElementType.Struct,
                                },
                        MethodCallback = NameHasNonEnglishCharacter.Validate
                    });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = TooManyComment.Validate });

            this.ElementVisitorRegistry.Add(new ElementVisitorContainer { ElementTypes = new List<ElementType> { ElementType.Method }, MethodCallback = MethodNameHasTooManyWord.Validate });
        }

        /// <summary>
        ///   Registers the rules that are meant to be executed by the expression visitor delegate.
        /// </summary>
        public void RegisterExpressionVisitorRule()
        {
            this.ExpressionVisitorRegistry.Add(
                new ExpressionVisitorContainer { ExpressionTypes = new List<ExpressionType> { ExpressionType.Unary }, MethodCallback = ExpressionHasNegativeConditional.Validate });
        }

        /// <summary>
        ///   Registers the rules that are meant to be executed by the statement visitor delegate.
        /// </summary>
        public void RegisterStatementVisitorRule()
        {
            this.StatementVisitorRegistry.Add(
                new StatementVisitorContainer { StatementTypes = new List<StatementType> { StatementType.Block }, MethodCallback = BlockStatementMustNotBeEmpty.Validate });
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

            foreach (ElementVisitorContainer elementVisitorContainer in this.ElementVisitorRegistry)
            {
                if (elementVisitorContainer.ElementTypes.Contains(element.ElementType))
                {
                    elementVisitorContainer.MethodCallback(element, parentElement, context);
                }
            }

            return true;
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
            foreach (ExpressionVisitorContainer expressionVisitorContainer in this.ExpressionVisitorRegistry)
            {
                if (expressionVisitorContainer.ExpressionTypes.Contains(expression.ExpressionType))
                {
                    expressionVisitorContainer.MethodCallback(expression, parentExpression, parentStatement, parentElement, context);
                }
            }

            return true;
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
            foreach (StatementVisitorContainer statementVisitorContainer in this.StatementVisitorRegistry)
            {
                if (statementVisitorContainer.StatementTypes.Contains(statement.StatementType))
                {
                    statementVisitorContainer.MethodCallback(statement, parentExpression, parentStatement, parentElement, context);
                }
            }

            return true;
        }

        #endregion
    }
}