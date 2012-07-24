// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodContainsSwitchStatementTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the MethodContainsSwitchStatement custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;

    /// <summary>
    ///   Dummy class to unit test the MethodContainsSwitchStatement custom StyleCop rule.
    /// </summary>
    public class MethodContainsSwitchStatementTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Methods has switch statement.
        /// </summary>
        /// <param name="paramForSwitch">
        /// The param for switch.
        /// </param>
        public void MethodHasSwitchStatement(string paramForSwitch)
        {
            switch (paramForSwitch)
            {
                case "1":
                    Console.WriteLine("one");
                    break;

                case "2":
                    Console.WriteLine("two");
                    break;

                default:
                    Console.WriteLine("not important");
                    break;
            }
        }

        #endregion
    }
}