// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViolationMergerTest.cs" company="CGI">
//   Copyright (c) CGI. All rights reserved.
// </copyright>
// <summary>
//   The violation merger test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopMergeAndStyle.Test
{
    using System.Collections.Generic;
    using System.IO;

    using NUnit.Framework;

    using StyleCopMergeAndStyle.Struct;

    /// <summary>
    /// The violation merger test.
    /// </summary>
    [TestFixture]
    public class ViolationMergerTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// The merge.
        /// </summary>
        [Test]
        public void Merge()
        {
            MergeAndStyleConfig mergeAndStyleConfig = ConfigReader.GetConfiguration(@".\Resource\Valid.config");

            string mergedValidation = ViolationMerger.Merge(mergeAndStyleConfig.ViolationFiles);

            Assert.IsNotNull(mergedValidation);
        }

        /// <summary>
        /// The merge with bad file.
        /// </summary>
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void MergeWithBadFile()
        {
            string mergedValidation = ViolationMerger.Merge(new List<string> { "BADBADBAD.xml" });

            Assert.IsNotNull(mergedValidation);
        }

        /// <summary>
        /// The merge with empty.
        /// </summary>
        [Test]
        public void MergeWithEmpty()
        {
            string mergedValidation = ViolationMerger.Merge(new List<string>());

            Assert.IsNotNull(mergedValidation);
        }

        #endregion
    }
}