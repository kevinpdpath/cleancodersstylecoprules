// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodContainsGotoStatementTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the MethodContainsGotoStatement custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;

    /// <summary>
    ///   Dummy class to unit test the MethodContainsGotoStatement custom StyleCop rule.
    /// </summary>
    public class MethodContainsGotoStatementTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Methods has goto statement.
        /// </summary>
        /// <param name="number">
        /// The param number.
        /// </param>
        public void HasGotoStatement(int? number)
        {
            if (number == null)
            {
                goto Finish;
            }
            else if (number == int.MinValue)
            {
                goto Found;
            }
            else if (number == int.MaxValue)
            {
                goto Finish;
            }

            Console.Write("hello");

            Found:
            Console.WriteLine("The number {0} is found.", number);

            Finish:
            Console.WriteLine("We are done.");
        }

        #endregion
    }
}