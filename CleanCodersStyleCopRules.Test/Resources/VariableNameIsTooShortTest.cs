// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameIsTooShortTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the VariableNameIsTooShort custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///   Dummy class to unit test the VariableNameIsTooShort custom StyleCop rule.
    /// </summary>
    public class VariableNameIsTooShortTest
    {
        #region Fields

        /// <summary>
        ///   The first name.
        /// </summary>
        private string firstName;

        /// <summary>
        ///   Variable too short.
        /// </summary>
        private string i;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Methods definition with one error.
        /// </summary>
        public void MethodWithOneErrors()
        {
            string c;

            string colorName;
        }

        /// <summary>
        /// Methods definition with two error.
        /// </summary>
        /// <param name="x">
        /// The parameter x.
        /// </param>
        /// <param name="y">
        /// The parameter y.
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0055:TooManyComment", Justification = "Euh, well, it need a little explaining here.")]
        public void MethodWithTwoErrors(int x, int y)
        {
            // Variables inside a for loop are accepted, but keep the for loop within 5 lines long.
            for (int z = 0; z < int.MaxValue; z++)
            {
                Console.WriteLine("Hello there: {0}", z);
            }
        }

        #endregion
    }
}