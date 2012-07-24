// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineIsTooLongTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the LineTooLong custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    /// <summary>
    /// Dummy class to unit test the LineTooLong custom StyleCop rule.
    /// </summary>
    public class LineIsTooLongTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Methods with a too long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long decription.
        /// </summary>
        public void MethodWithError()
        {
            string longLine =
                "long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long  long";
        }

        #endregion
    }
}