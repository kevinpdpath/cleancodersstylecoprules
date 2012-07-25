// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodHasBooleanParameterTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the MethodHasBooleanParameter custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    ///   Dummy class to unit test the MethodHasBooleanParameter custom StyleCop rule.
    /// </summary>
    public class MethodHasBooleanParameterTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Methods the with output parameter, in a DLL Import.
        /// </summary>
        /// <param name="isMale">
        /// The flag that DOES NOT violates the rule.
        /// </param>
        /// <returns>
        /// The method with output parameter in dll import.
        /// </returns>
        [DllImport("dummy.so")]
        public static extern int WithOutputParameterInDllImport(bool isMale);

        /// <summary>
        /// Methods the with boolean parameter.
        /// </summary>
        /// <param name="flag">
        /// If set to <c>true</c> [do this or that], hence, two responsabilities, which is bad.
        /// </param>
        public void WithBooleanParameter(bool flag)
        {
            if (flag)
            {
                Console.WriteLine("Something...");
            }
            else
            {
                Console.WriteLine("Something...");
            }
        }

        #endregion
    }
}