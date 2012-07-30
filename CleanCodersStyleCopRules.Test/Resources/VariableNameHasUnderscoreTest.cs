// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameHasUnderscoreTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the VariableNameHasUnderscore custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Globalization;

    /// <summary>
    ///   Dummy class to unit test the VariableNameHasUnderscore custom StyleCop rule.
    /// </summary>
    public class VariableNameHasUnderscoreTest
    {
        #region Fields

        /// <summary>
        ///   Member variable containing an underscore.
        /// </summary>
        private string _somevariable;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Methods definition with one error.
        /// </summary>
        /// <param name="last_name">
        /// The parameter last_name.
        /// </param>
        public void WithOneErrors(int last_name)
        {
        }

        /// <summary>
        /// Methods definition with many errors.
        /// </summary>
        /// <param name="age">
        /// The parameter age.
        /// </param>
        /// <param name="year_of_birth">
        /// The parameter year_of_birth.
        /// </param>
        public void WithManyErrors(int age, int year_of_birth)
        {
            string color_name;

            for (int cone_number = 0; cone_number < 100; cone_number++)
            {
                Console.WriteLine("Hello {0}", cone_number.ToString(CultureInfo.InvariantCulture));
            }
        }

        #endregion
    }
}