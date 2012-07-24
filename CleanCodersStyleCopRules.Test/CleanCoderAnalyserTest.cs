// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CleanCoderAnalyserTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   The tests for the Clean Coder analyzer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test
{
    using NUnit.Framework;

    /// <summary>
    ///   The tests for the Clean Coder analyzer.
    /// </summary>
    [TestFixture]
    public class CleanCoderAnalyserTest : TestFixtureBase
    {
        #region Public Methods and Operators

        /// <summary>
        ///   The block statement must not be empty.
        /// </summary>
        [Test]
        public void BlockStatementMustNotBeEmpty()
        {
            this.AnalyzeCodeWithAssertion("BlockStatementMustNotBeEmptyTest.cs", 2);
        }

        /// <summary>
        ///   The class contains too many line.
        /// </summary>
        [Test]
        public void ClassContainsTooManyLine()
        {
            this.AnalyzeCodeWithAssertion("ClassContainsTooManyLineTest.cs", 1);
        }

        /// <summary>
        ///   The class contains too many method.
        /// </summary>
        [Test]
        public void ClassContainsTooManyMethod()
        {
            this.AnalyzeCodeWithAssertion("ClassContainsTooManyMethodTest.cs", 1);
        }

        /// <summary>
        ///   The class name has too many word.
        /// </summary>
        [Test]
        public void ClassNameHasTooManyWord()
        {
            this.AnalyzeCodeWithAssertion("ClassNameHasTooManyWordTest.cs", 1);
        }

        /// <summary>
        ///   The expression has negative conditional.
        /// </summary>
        [Test]
        public void ExpressionHasNegativeConditional()
        {
            this.AnalyzeCodeWithAssertion("ExpressionHasNegativeConditionalTest.cs", 3);
        }

        /// <summary>
        ///   The file name must match type name class.
        /// </summary>
        [Test]
        public void FileNameMustMatchTypeNameClass()
        {
            this.AnalyzeCodeWithAssertion("FileNameMustMatchTypeNameTestClass.cs", 1);
        }

        /// <summary>
        ///   The file name must match type name interface.
        /// </summary>
        [Test]
        public void FileNameMustMatchTypeNameInterface()
        {
            this.AnalyzeCodeWithAssertion("FileNameMustMatchTypeNameTestInterface.cs", 1);
        }

        /// <summary>
        ///   The file name must match type name partial 1.
        /// </summary>
        [Test]
        public void FileNameMustMatchTypeNamePartial1()
        {
            this.AnalyzeCodeWithAssertion("FileNameMustMatchTypeNameTestPartial.cs", 1);
        }

        /// <summary>
        ///   The file name must match type name partial 2.
        /// </summary>
        [Test]
        public void FileNameMustMatchTypeNamePartial2()
        {
            this.AnalyzeCodeWithAssertion("FileNameMustMatchTypeNameTestPartial.Designer.cs", 1);
        }

        /// <summary>
        ///   The file name must match type name struct.
        /// </summary>
        [Test]
        public void FileNameMustMatchTypeNameStruct()
        {
            this.AnalyzeCodeWithAssertion("FileNameMustMatchTypeNameTestStruct.cs", 1);
        }

        /// <summary>
        ///   The line contains train wreck.
        /// </summary>
        [Test]
        public void LineContainsTrainWreck()
        {
            this.AnalyzeCodeWithAssertion("LineContainsTrainWreckTest.cs", 1);
        }

        /// <summary>
        ///   The line has trailing space.
        /// </summary>
        [Test]
        public void LineHasTrailingSpace()
        {
            this.AnalyzeCodeWithAssertion("LineHasTrailingSpaceTest.cs", 3);
        }

        /// <summary>
        ///   The line is too long.
        /// </summary>
        [Test]
        public void LineIsTooLong()
        {
            this.AnalyzeCodeWithAssertion("LineIsTooLongTest.cs", 2);
        }

        /// <summary>
        ///   The method contains goto statement.
        /// </summary>
        [Test]
        public void MethodContainsGotoStatement()
        {
            this.AnalyzeCodeWithAssertion("MethodContainsGotoStatementTest.cs", 3);
        }

        /// <summary>
        ///   The method contains switch statement.
        /// </summary>
        [Test]
        public void MethodContainsSwitchStatement()
        {
            this.AnalyzeCodeWithAssertion("MethodContainsSwitchStatementTest.cs", 1);
        }

        /// <summary>
        ///   The method contains too many line.
        /// </summary>
        [Test]
        public void MethodContainsTooManyLine()
        {
            this.AnalyzeCodeWithAssertion("MethodContainsTooManyLineTest.cs", 1);
        }

        /// <summary>
        ///   The method has boolean parameter.
        /// </summary>
        [Test]
        public void MethodHasBooleanParameter()
        {
            this.AnalyzeCodeWithAssertion("MethodHasBooleanParameterTest.cs", 1);
        }

        /// <summary>
        ///   The method has output parameter.
        /// </summary>
        [Test]
        public void MethodHasOutputParameter()
        {
            this.AnalyzeCodeWithAssertion("MethodHasOutputParameterTest.cs", 1);
        }

        /// <summary>
        ///   The method has too many argument.
        /// </summary>
        [Test]
        public void MethodHasTooManyArgument()
        {
            this.AnalyzeCodeWithAssertion("MethodHasTooManyArgumentTest.cs", 1);
        }

        /// <summary>
        /// The method name has too many word.
        /// </summary>
        [Test]
        public void MethodNameHasTooManyWord()
        {
            this.AnalyzeCodeWithAssertion("MethodNameHasTooManyWordTest.cs", 1);
        }

        /// <summary>
        ///   The name has non english character.
        /// </summary>
        [Test]
        public void NameHasNonEnglishCharacter()
        {
            this.AnalyzeCodeWithAssertion("NameHasNonEnglishCharacterTest.cs", 24);
        }

        /// <summary>
        ///   The property contains too many line.
        /// </summary>
        [Test]
        public void PropertyContainsTooManyLine()
        {
            this.AnalyzeCodeWithAssertion("PropertyContainsTooManyLineTest.cs", 1);
        }

        /// <summary>
        ///   The too many comment.
        /// </summary>
        [Test]
        public void TooManyComment()
        {
            this.AnalyzeCodeWithAssertion("TooManyCommentTest.cs", 1);
        }

        /// <summary>
        ///   The variable name has hungarian prefix.
        /// </summary>
        [Test]
        public void VariableNameHasHungarianPrefix()
        {
            this.AnalyzeCodeWithAssertion("VariableNameHasHungarianPrefixTest.cs", 13);
        }

        /// <summary>
        ///   The variable name has underscore.
        /// </summary>
        [Test]
        public void VariableNameHasUnderscore()
        {
            this.AnalyzeCodeWithAssertion("VariableNameHasUnderscoreTest.cs", 4);
        }

        /// <summary>
        ///   The variable name is not plural.
        /// </summary>
        [Test]
        public void VariableNameIsNotPlural()
        {
            this.AnalyzeCodeWithAssertion("VariableNameIsNotPluralTest.cs", 34);
        }

        /// <summary>
        ///   The variable name is too short.
        /// </summary>
        [Test]
        public void VariableNameIsTooShort()
        {
            this.AnalyzeCodeWithAssertion("VariableNameIsTooShortTest.cs", 4);
        }

        /// <summary>
        ///   The variable type is not explicit.
        /// </summary>
        [Test]
        public void VariableTypeIsNotExplicit()
        {
            this.AnalyzeCodeWithAssertion("VariableTypeIsNotExplicitTest.cs", 1);
        }

        #endregion
    }
}