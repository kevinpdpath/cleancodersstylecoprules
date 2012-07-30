// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameHasHungarianPrefixTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the VariableNameHasHungarianPrefix custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///   Dummy class to unit test the VariableNameHasHungarianPrefix custom StyleCop rule.
    /// </summary>
    public class VariableNameHasHungarianPrefixTest
    {
        #region Fields

        /// <summary>
        ///   The bln ready.
        /// </summary>
        private bool blnReady;

        /// <summary>
        ///   The dat birth day.
        /// </summary>
        private DateTime datBirthDay;

        /// <summary>
        ///   The dbl conversion rate.
        /// </summary>
        private double dblConversionRate;

        /// <summary>
        ///   The err failure message.
        /// </summary>
        private string errFailureMessage;

        /// <summary>
        ///   The int day of week.
        /// </summary>
        private int intDayOfWeek;

        /// <summary>
        ///   The lng earth size in meter.
        /// </summary>
        private long lngEarthSizeInMeter;

        /// <summary>
        ///   The sng property area.
        /// </summary>
        private float sngPropertyArea;

        /// <summary>
        ///   The first name with hungarian prefix.
        /// </summary>
        private string strFirstName;

        /// <summary>
        ///   The udt location.
        /// </summary>
        private Point udtLocation;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Methods definition with one error.
        /// </summary>
        /// <param name="lastName">
        /// The parameter lastName.
        /// </param>
        /// <param name="strSurName">
        /// The parameter strSurName.
        /// </param>
        public void WithOneErrors(int lastName, int strSurName)
        {
        }

        /// <summary>
        /// Methods definition with many error.
        /// </summary>
        /// <param name="intAge">
        /// The parameter intAge.
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0301:VariableTypeIsNotExplicit", Justification = "It's for a test.")]
        public void WithManyErrors(int intAge)
        {
            string colorName;

            string strColorName;

            DateTime vntDate = DateTime.Now;

            for (int intCount = 0; intCount < 100; intCount++)
            {
                bool blnFlag = true;
            }
        }

        /// <summary>
        /// Methods without errors.
        /// </summary>
        /// <param name="abc">
        /// The parameter abc.
        /// </param>
        /// <param name="def">
        /// The parameter def.
        /// </param>
        public void WithoutErrors(int abc, int def)
        {
            string lastName;
        }

        #endregion

        /// <summary>
        ///   Initializes a new instance of the <see cref="Point" /> struct.
        /// </summary>
        public struct Point
        {
            #region Fields

            /// <summary>
            ///   The coordinate x.
            /// </summary>
            public int CoordinateX;

            /// <summary>
            ///   The coordinate y.
            /// </summary>
            public int CoordinateY;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="Point"/> struct.
            /// </summary>
            /// <param name="intCoordinateX">
            /// The coordinate X.
            /// </param>
            /// <param name="intCoordinateY">
            /// The coordinate Y.
            /// </param>
            public Point(int intCoordinateX, int intCoordinateY)
            {
                this.CoordinateX = intCoordinateX;
                this.CoordinateY = intCoordinateY;
            }

            #endregion
        }
    }
}