// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TooManyCommentTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the TooManyComment custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;

    /// <summary>
    ///   Dummy class to unit test the TooManyComment custom StyleCop rule.
    /// </summary>
    public class TooManyCommentTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// The no comment.
        /// </summary>
        public void NoComment()
        {
            int abc = 0;
            Console.WriteLine(abc);
        }

        /// <summary>
        /// The one comment.
        /// </summary>
        public void TooLong()
        {
            // Initialize our variable.
            int abc = 0;
            abc += 1;
            abc += 2;
            abc += 3;
            abc += 4;
            abc += 5;
            abc += 6;
            abc += 7;
            abc += 8;
            abc += 9;
            abc += 10;
            abc += 11;
            abc += 12;
            abc += 13;
            abc += 14;
            abc += 15;
            abc += 16;
            abc += 17;
            abc += 18;
            abc += 19;
            abc += 20;
            abc += 21;
            abc += 22;
            abc += 23;
            abc += 24;
            abc += 25;
            abc += 26;
            abc += 27;
            abc += 28;
            abc += 29;
            abc += 30;
            abc += 31;
            abc += 32;
            abc += 33;
            abc += 34;
            abc += 35;
            abc += 36;
            abc += 37;
            abc += 38;
            abc += 39;
            abc += 40;
            abc += 41;
            abc += 42;
            abc += 43;
            abc += 44;
            Console.WriteLine(abc);
        }

        /// <summary>
        /// The noise comment.
        /// </summary>
        public void NoiseComment()
        {
            // Initialize our variable.
            int abc = 0;

            // Add one more to our variable.
            abc += 1;

            // Add one more to our variable.
            abc += 2;

            // Add one more to our variable.
            abc += 3;

            // Add one more to our variable.
            abc += 4;

            // Add one more to our variable.
            abc += 5;

            // Add one more to our variable.
            abc += 6;

            // Add one more to our variable.
            abc += 7;

            // Add one more to our variable.
            abc += 8;

            // Add one more to our variable.
            abc += 9;

            // Add one more to our variable.
            abc += 10;

            // Add one more to our variable.
            abc += 11;

            // Add one more to our variable.
            abc += 12;

            // Add one more to our variable.
            abc += 13;

            Console.WriteLine(abc);
        }

        #endregion
    }
}