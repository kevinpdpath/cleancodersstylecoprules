// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodHasTooManyArgumentTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the MethodHasTooManyArgument custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    ///   Dummy class to unit test the MethodHasTooManyArgument custom StyleCop rule.
    /// </summary>
    public class MethodHasTooManyArgumentTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Methods definition with the maximum number of arguments.
        /// </summary>
        /// <param name="abc">
        /// The parameter abc.
        /// </param>
        /// <param name="def">
        /// The parameter def.
        /// </param>
        /// <param name="ghi">
        /// The ghi.
        /// </param>
        /// <param name="klm">
        /// The klm.
        /// </param>
        public void WithMaximumNumberOfArgument(int abc, int def, int ghi, int klm)
        {
        }

        /// <summary>
        /// Methods definition with one argument.
        /// </summary>
        /// <param name="abc">
        /// The parameter abc.
        /// </param>
        public void WithOneArgument(int abc)
        {
        }

        /// <summary>
        /// Methods definition with too many arguments.
        /// </summary>
        /// <param name="abc">
        /// The parameter abc.
        /// </param>
        /// <param name="def">
        /// The parameter def.
        /// </param>
        /// <param name="ghi">
        /// The parameter ghi.
        /// </param>
        public void WithTooManyArgument(int abc, int def, int ghi)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Methods definition with too many arguments, but importing a DLL (which is allowable).
        /// </summary>
        /// <param name="tmpPath">
        /// The temporary path.
        /// </param>
        /// <param name="prefix">
        /// The prefix.
        /// </param>
        /// <param name="uniqueIdOrZero">
        /// The unique id or zero.
        /// </param>
        /// <param name="tmpFileName">
        /// Name of the temporary file.
        /// </param>
        /// <returns>
        /// Returns a temporary file name.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        internal static extern uint GetTempFileName(string tmpPath, string prefix, uint uniqueIdOrZero, StringBuilder tmpFileName);

        #endregion
    }
}