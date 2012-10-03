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
        ///   Variable too short.
        /// </summary>
        private string i;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNameIsTooShortTest"/> class.
        /// </summary>
        /// <param name="i">
        /// The i. 
        /// </param>
        public VariableNameIsTooShortTest(string i)
        {
            this.i = i;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Methods definition with many error.
        /// </summary>
        /// <param name="x">
        /// The parameter x. 
        /// </param>
        /// <param name="y">
        /// The parameter y. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0055:TooManyComment", Justification = "Euh, well, it need a little explaining here.")]
        public void WithManyErrors(int x, int y)
        {
            // Short variables initializing the for statement are accepted, the loop must be 10 lines or less.
            for (int z = 0; z < int.MaxValue; z++)
            {
                int j = 0;
                Console.WriteLine("Hello there: {0}", z);
                Console.WriteLine("Hello there: {0}", z);
                Console.WriteLine("Hello there: {0}", z);
                Console.WriteLine("Hello there: {0}", z);
                Console.WriteLine("Hello there: {0}, {1}", z, j);
            }

            for (int k = 0; k < int.MaxValue; k++)
            {
                int h = 0;
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}", k);
                Console.WriteLine("Hello there: {0}, {1}", k, h);
            }

            if (true)
            {
                int o = 2;

                // Short variables initializing the for statement are accepted, the loop must be 10 lines or less.
                for (int q = 0; q < int.MaxValue; q++)
                {
                    Console.WriteLine("Hello there: {0}, {1}", q, o);

                    if (true)
                    {
                        int u = 0;
                    }
                }
            }
        }

        /// <summary>
        ///   Methods definition with one error.
        /// </summary>
        public void WithOneErrors()
        {
            string c = string.Empty;

            Console.WriteLine("Hello there: {0}", c);
        }

        #endregion

        /// <summary>
        ///   The some container.
        /// </summary>
        public struct SomeContainer
        {
            #region Fields

            /// <summary>
            ///   The A.
            /// </summary>
            public int A;

            /// <summary>
            ///   The B.
            /// </summary>
            public int B;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="SomeContainer"/> struct.
            /// </summary>
            /// <param name="a">
            /// The a. 
            /// </param>
            /// <param name="b">
            /// The b. 
            /// </param>
            public SomeContainer(int a, int b)
            {
                this.A = a;
                this.B = b;
            }

            #endregion

            #region Enums

            /// <summary>
            ///   The vowel.
            /// </summary>
            public enum Vowel
            {
                /// <summary>
                ///   The a.
                /// </summary>
                A, 

                /// <summary>
                ///   The e.
                /// </summary>
                E, 

                /// <summary>
                ///   The i.
                /// </summary>
                I, 

                /// <summary>
                ///   The o.
                /// </summary>
                O, 

                /// <summary>
                ///   The u.
                /// </summary>
                U, 

                /// <summary>
                ///   The y.
                /// </summary>
                Y
            }

            #endregion
        }
    }
}