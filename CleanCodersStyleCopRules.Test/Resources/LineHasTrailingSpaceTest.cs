// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineHasTrailingSpaceTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the LineHasTrailingSpace custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;

    /// <summary>
    ///   Dummy class to unit test the LineHasTrailingSpace custom StyleCop rule.
    /// </summary>
    public class LineHasTrailingSpaceTest
    {
        #region Public Methods and Operators

        /// <summary>           
        ///   The test 1.     
        /// </summary>          
        public void Test1()   
        {
            if (true)
            {
                Console.WriteLine("Hello");
            }

            while (true)        
            {
                Console.WriteLine("Hello");
            }                   
        }

        #endregion
    }
}