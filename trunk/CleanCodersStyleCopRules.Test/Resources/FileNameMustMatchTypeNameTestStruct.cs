// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileNameMustMatchTypeNameTestStruct.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Initializes a new instance of the  struct.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    /// <summary>
    ///   Initializes a new instance of the <see cref="Coordinate" /> struct.
    /// </summary>
    public struct Coordinate
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
        /// Initializes a new instance of the <see cref="Coordinate"/> struct.
        /// </summary>
        /// <param name="coordinateX">
        /// The coordinate X.
        /// </param>
        /// <param name="coordinateY">
        /// The coordinate Y.
        /// </param>
        public Coordinate(int coordinateX, int coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }

        #endregion
    }
}