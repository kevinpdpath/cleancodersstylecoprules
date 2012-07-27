// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodContainsTooManyLineTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the MethodContainsTooManyLine custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///   Dummy class to unit test the MethodContainsTooManyLine custom StyleCop rule.
    /// </summary>
    public class MethodContainsTooManyLineTest
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Method that is 50 lines long, that includes the squidlies, but exclude the method declatation line.
        /// </summary>
        public void FiftyLine()
        {
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
            abc += 45;
            Console.WriteLine(abc);
        }

        /// <summary>
        ///   Methods definition with Four error.
        /// </summary>
        public void TooLong()
        {
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
            abc += 45;
            abc += 46;
            abc += 47;
            abc += 48;
            abc += 49;
            abc += 50;
            abc += 51;
            abc += 52;
            abc += 53;
            abc += 54;
            abc += 55;
            abc += 56;
            abc += 57;
            abc += 58;
            abc += 59;
            Console.WriteLine(abc);
        }

        /// <summary>
        ///   Short method, no lines, well, actually, 2, the squidlies are counted in the body of the method.
        /// </summary>
        public void Short()
        {
        }

        #endregion
    }
}