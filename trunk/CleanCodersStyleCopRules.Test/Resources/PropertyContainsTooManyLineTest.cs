// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyContainsTooManyLineTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the PropertyContainsTooManyLine custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Globalization;

    /// <summary>
    ///   Dummy class to unit test the PropertyContainsTooManyLine custom StyleCop rule.
    /// </summary>
    public class PropertyContainsTooManyLineTest
    {
        #region Fields

        /// <summary>
        /// The is it cloudy.
        /// </summary>
        private bool isItCloudy;

        /// <summary>
        /// The is it sunny.
        /// </summary>
        private bool isItSunny;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether is it cloudy.
        /// </summary>
        public bool IsItCloudy
        {
            get
            {
                return this.isItCloudy;
            }

            set
            {
                this.isItCloudy = value;

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));

                Console.WriteLine("Cloudy's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is it sunny.
        /// </summary>
        public bool IsItSunny
        {
            get
            {
                return this.isItSunny;
            }

            set
            {
                this.isItSunny = value;
                Console.WriteLine("1 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("2 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("3 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("4 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("5 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("6 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("7 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("8 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("9 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("10 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("11 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("12 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("13 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("14 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("15 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("16 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("17 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("18 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("19 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("20 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("21 Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Gets or sets the prop 1.
        /// </summary>
        public string SelfDeclared { get; set; }

        #endregion
    }
}