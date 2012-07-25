// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlockStatementMustNotBeEmptyTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the BlockStatementMustNotBeEmpty custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    /// <summary>
    ///   Dummy class to unit test the BlockStatementMustNotBeEmpty custom StyleCop rule.
    /// </summary>
    public class BlockStatementMustNotBeEmptyTest
    {
        #region Public Methods and Operators

        /// <summary>
        ///   The test 1.
        /// </summary>
        public void Test1()
        {
            if (true)
            {
            }

            while (true)
            {
            }
        }

        #endregion
    }
}