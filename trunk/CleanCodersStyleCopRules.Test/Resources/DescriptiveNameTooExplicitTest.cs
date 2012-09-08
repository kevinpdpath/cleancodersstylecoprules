// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DescriptiveNameTooExplicitTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   The descriptive name too explicit test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The descriptive name too explicit test.
    /// </summary>
    public class DescriptiveNameTooExplicitTest
    {
        #region Fields

        /// <summary>
        /// The my field.
        /// </summary>
        private string myField;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the get set property.
        /// </summary>
        public string GetSetProperty { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The method 1.
        /// </summary>
        private void Method1()
        {
            Console.WriteLine("hello");
        }

        #endregion
    }

    /// <summary>
    /// The my class.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It's for a test.")]
    public class MyClass
    {
        /// <summary>
        /// The toto.
        /// </summary>
        private string toto;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyClass"/> class.
        /// </summary>
        /// <param name="toto">
        /// The toto.
        /// </param>
        public MyClass(string toto)
        {
            this.toto = toto;

            Console.WriteLine(toto);
        }
    }

    /// <summary>
    ///   The Enum Must Not Contain Word Enum.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "It's for a test.")]
    public enum EnumMustNotContainWordEnum
    {
        /// <summary>
        ///   The choice 1.
        /// </summary>
        Choice1, 

        /// <summary>
        ///   The enum choice 2.
        /// </summary>
        EnumItemChoice2, 

        /// <summary>
        ///   The choice 3.
        /// </summary>
        Choice3
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="CoordinateStruct" /> struct.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "It's for a test.")]
    public struct CoordinateStruct
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
        /// Initializes a new instance of the <see cref="CoordinateStruct"/> struct.
        /// </summary>
        /// <param name="coordinateX">
        /// The coordinate X. 
        /// </param>
        /// <param name="coordinateY">
        /// The coordinate Y. 
        /// </param>
        public CoordinateStruct(int coordinateX, int coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }

        #endregion
    }

    /// <summary>
    /// The SomeInterface interface.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "It's for a test.")]
    public interface ISomeInterface
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }
    }
}