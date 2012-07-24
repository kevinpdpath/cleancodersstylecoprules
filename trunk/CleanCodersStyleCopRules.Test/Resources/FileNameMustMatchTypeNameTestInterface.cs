// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileNameMustMatchTypeNameTestInterface.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   The Xenomorph interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    /// <summary>
    /// The Xenomorph interface.
    /// </summary>
    public interface IXenomorph
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets a value indicating whether our xenomorph is freindly or not;
        /// </summary>
        bool Freindly { get; set; }

        /// <summary>
        ///   Gets or sets the number of leg for our xenomorph.
        /// </summary>
        int NumberOfLeg { get; set; }

        #endregion
    }
}