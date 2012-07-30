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
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    ///   Dummy class to unit test the VariableNameHasUnderscore custom StyleCop rule.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "It's for a test.")]
    public class VariableNameHasUnderscoreTest
    {
        #region Fields

        /// <summary>
        ///   Member variable containing an underscore.
        /// </summary>
        private string _somevariable;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNameHasUnderscoreTest"/> class.
        /// </summary>
        /// <param name="some_variable">
        /// The some_variable.
        /// </param>
        public VariableNameHasUnderscoreTest(string some_variable)
        {
            this._somevariable = some_variable;
        }

        #endregion

        #region Public Methods and Operators

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

                int some_int = 0;
            }
        }

        /// <summary>
        /// Methods definition with one error.
        /// </summary>
        /// <param name="last_name">
        /// The parameter last_name. 
        /// </param>
        public void WithOneErrors(int last_name)
        {
        }

        #endregion

        /// <summary>
        ///   The some container.
        /// </summary>
        public struct SomeContainer
        {
            #region Fields

            /// <summary>
            ///   The array list darkness.
            /// </summary>
            public ArrayList SomeDarkness;

            /// <summary>
            ///   The array list light.
            /// </summary>
            public ArrayList SomeLights;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="SomeContainer"/> struct.
            /// </summary>
            /// <param name="some_lights">
            /// The some_lights. 
            /// </param>
            /// <param name="some_darkness">
            /// The some_darkness. 
            /// </param>
            public SomeContainer(ArrayList some_lights, ArrayList some_darkness)
            {
                this.SomeLights = some_lights;
                this.SomeDarkness = some_darkness;
            }

            #endregion
        }
    }
}