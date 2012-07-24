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
        /// The is it sunny.
        /// </summary>
        private bool isItSunny;

        #endregion

        #region Public Properties

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
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine("Sunny's flag is set to: {0}", this.isItSunny.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Gets or sets the prop 1.
        /// </summary>
        public string SelfDeclared { get; set; }

        #endregion
    }
}