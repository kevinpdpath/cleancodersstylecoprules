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
        #region Public Methods and Operators

        /// <summary>
        ///   Methods definition with one error.
        /// </summary>
        public void MethodWithOneError()
        {
            var date = DateTime.Now;
        }

        #endregion
    }
}