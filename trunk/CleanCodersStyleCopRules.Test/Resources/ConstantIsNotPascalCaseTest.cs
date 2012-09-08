// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantIsNotPascalCaseTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the ConstantIsNotPascalCase custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///   Dummy class to unit test the ConstantIsNotPascalCase custom StyleCop rule.
    /// </summary>
    [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0022:VariableNameHasUnderscore", Justification = "Its for a test.")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Its for a test.")]
    public class ConstantIsNotPascalCaseTest
    {
        #region Constants

        /// <summary>
        ///   The all caps constant.
        /// </summary>
        public const string ALL_CAPS_CONSTANT = "abc";

        /// <summary>
        ///   The pascal case constant.
        /// </summary>
        public const string PascalCaseConstant = "Abc";

        /// <summary>
        ///   The screamingcaps.
        /// </summary>
        public const string SCREAMINGCAPS = "abc";

        /// <summary>
        ///   The constant all caps again.
        /// </summary>
        private const string CONSTANTALL_CAPS_AGAIN = "abc";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The test 1.
        /// </summary>
        public void Test1()
        {
            const string LOCAL_ALL_CAPS_CONSTANT = "abc";

            Console.WriteLine("Hello there: {0}", LOCAL_ALL_CAPS_CONSTANT);

            const string LocalPascalCaseConstant = "Abc";

            Console.WriteLine("Hello there: {0}", LocalPascalCaseConstant);

            const string LOCALSCREAMINGCAPS = "abc";

            Console.WriteLine("Hello there: {0}", LOCALSCREAMINGCAPS);

            const string LOCAL_CONSTANTALL_CAPS_AGAIN = "abc";

            Console.WriteLine("Hello there: {0}", LOCAL_CONSTANTALL_CAPS_AGAIN);

            if (true)
            {
                const string TTTTUUUU = "abc;";

                Console.WriteLine("Hello there: {0}", TTTTUUUU);

                for (int i = 0; i < 10; i++)
                {
                    const string EEEERRRR = "abc";

                    Console.WriteLine("Hello there: {0}", EEEERRRR);
                }
            }
        }

        #endregion
    }
}