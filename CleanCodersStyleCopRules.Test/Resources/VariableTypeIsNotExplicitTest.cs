// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableTypeIsNotExplicitTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the VariableTypeIsNotExplicit custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;

    /// <summary>
    ///   Dummy class to unit test the VariableTypeIsNotExplicit custom StyleCop rule.
    /// </summary>
    public class VariableTypeIsNotExplicitTest
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="VariableTypeIsNotExplicitTest" /> class.
        /// </summary>
        public VariableTypeIsNotExplicitTest()
        {
            var date1 = DateTime.Now;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Methods definition with one error.
        /// </summary>
        public void WithOneError()
        {
            var date2 = DateTime.Now;

            foreach (var someVar in DateTime.Now.ToLongTimeString().ToCharArray())
            {
                var date4 = DateTime.Now;
            }
        }

        #endregion

        /// <summary>
        ///   The some container.
        /// </summary>
        public struct SomeContainer
        {
            #region Fields

            /// <summary>
            ///   The Abc.
            /// </summary>
            public int Abc;

            /// <summary>
            ///   The Def.
            /// </summary>
            public int Def;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="SomeContainer"/> struct.
            /// </summary>
            /// <param name="abc">
            /// The Abc. 
            /// </param>
            /// <param name="def">
            /// The Def. 
            /// </param>
            public SomeContainer(int abc, int def)
            {
                this.Abc = abc;
                this.Def = def;

                var date3 = DateTime.Now;
            }

            #endregion
        }
    }
}