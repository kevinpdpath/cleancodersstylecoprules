// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineContainsTrainWreckTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the LineContainsTrainWreck custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///   Dummy class to unit test the LineContainsTrainWreck custom StyleCop rule.
    /// </summary>
    public class LineContainsTrainWreckTest
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Methods definition with one error.
        /// </summary>
        public void TrainWreckExpression()
        {
            Person me = new Person();

            string closestCityNameWhereGrandpaWasBorn = me.Father.Father.GetBirthInformation().GetWhere().GetClosestCityLocation().GetLocationName();

            Console.WriteLine(closestCityNameWhereGrandpaWasBorn);
        }

        #endregion
    }

    /// <summary>
    ///   The person.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It's for a test.")]
    public class Person
    {
        #region Fields

        /// <summary>
        ///   The birth information.
        /// </summary>
        private readonly BirthInformation birthInfo = new BirthInformation();

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets Father.
        /// </summary>
        public Person Father { get; set; }

        /// <summary>
        ///   Gets or sets FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///   Gets or sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///   Gets or sets Mother.
        /// </summary>
        public Person Mother { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   The get birth information.
        /// </summary>
        /// <returns> The CleanCodersStyleCopRules.Test.Resources.BirthInformation. </returns>
        public BirthInformation GetBirthInformation()
        {
            return this.birthInfo;
        }

        #endregion
    }

    /// <summary>
    ///   The birth information.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It's for a test.")]
    public class BirthInformation
    {
        #region Fields

        /// <summary>
        /// The location where. 
        /// </summary>
        private readonly Location where = new Location();

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets CityName.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        ///   Gets or sets Doctor.
        /// </summary>
        public Person Doctor { get; set; }

        /// <summary>
        ///   Gets or sets When.
        /// </summary>
        public DateTime When { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   The get where.
        /// </summary>
        /// <returns> The CleanCodersStyleCopRules.Test.Resources.Location. </returns>
        public Location GetWhere()
        {
            return this.where;
        }

        #endregion
    }

    /// <summary>
    ///   The location.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It's for a test.")]
    public class Location
    {
        #region Fields

        /// <summary>
        ///   The place name.
        /// </summary>
        private string placeName = string.Empty;

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets Coordinate.
        /// </summary>
        public Point Coordinate { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   The get closest city location.
        /// </summary>
        /// <returns> The System.String. </returns>
        public Location GetClosestCityLocation()
        {
            return new Location();
        }

        /// <summary>
        ///   The get location name.
        /// </summary>
        /// <returns> The System.String. </returns>
        public string GetLocationName()
        {
            return string.Empty;
        }

        #endregion
    }

    /// <summary>
    ///   The point.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It's for a test.")]
    public class Point
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets CoordonnéeX.
        /// </summary>
        public double CoordinateX { get; set; }

        /// <summary>
        ///   Gets or sets CoordonnéeY.
        /// </summary>
        public double CoordinateY { get; set; }

        #endregion
    }
}