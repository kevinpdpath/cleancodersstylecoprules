// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionHasNegativeConditionalTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the ExpressionContainsNegativeConditional custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;

    /// <summary>
    ///   Dummy class to unit test the ExpressionContainsNegativeConditional custom StyleCop rule.
    /// </summary>
    public class ExpressionHasNegativeConditionalTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Methods definition with two error.
        /// </summary>
        /// <param name="year1">
        /// The parameter year.
        /// </param>
        /// <param name="year2">
        /// The parameter year2.
        /// </param>
        public void WithTwoErrors(int year1, int year2)
        {
            if (DateTime.IsLeapYear(year1))
            {
                Console.WriteLine("{0} is a leap year", year1);
            }

            if (!DateTime.IsLeapYear(year2))
            {
                Console.WriteLine("{0} is not a leap year", year2);
            }

            if (DateTime.IsLeapYear(year1) && !DateTime.IsLeapYear(year2))
            {
                Console.WriteLine("Bah, who cares.");
            }

            bool notTrue = !true;
        }

        #endregion
    }
}