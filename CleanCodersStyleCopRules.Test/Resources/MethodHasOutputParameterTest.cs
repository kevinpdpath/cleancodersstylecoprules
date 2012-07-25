// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodHasOutputParameterTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the MethodHasOutputParameter custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    ///   Dummy class to unit test the MethodHasOutputParameter custom StyleCop rule.
    /// </summary>
    public class MethodHasOutputParameterTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Methods the with output parameter, in a DLL Import.
        /// </summary>
        /// <param name="outputParam">
        /// The output parameter that violates the rule.
        /// </param>
        /// <returns>
        /// The method with output parameter in dll import.
        /// </returns>
        [DllImport("dummy.so")]
        public static extern int WithOutputParameterInDllImport(out IntPtr outputParam);

        /// <summary>
        /// Methods the with output parameter.
        /// </summary>
        /// <param name="outputParam">
        /// The output parameter that violates the rule.
        /// </param>
        public void WithOutputParameter(out string outputParam)
        {
            outputParam = "Hello World";
        }

        #endregion
    }
}