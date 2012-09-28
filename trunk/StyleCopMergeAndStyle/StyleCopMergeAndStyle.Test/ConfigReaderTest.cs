// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigReaderTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopMergeAndStyle.Test
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using StyleCopMergeAndStyle.Struct;

    /// <summary>
    ///   The config reader test.
    /// </summary>
    [TestFixture]
    public class ConfigReaderTest
    {
        #region Public Methods and Operators

        /// <summary>
        ///   The get configuration.
        /// </summary>
        [Test]
        public void GetConfiguration()
        {
            MergeAndStyleConfig mergeAndStyleConfig = ConfigReader.GetConfiguration(@".\Resource\Valid.config");

            Assert.NotNull(mergeAndStyleConfig.ViolationFiles);

            Assert.IsNotNullOrEmpty(mergeAndStyleConfig.MergeFileName);
        }

        /// <summary>
        ///   The constructor with invalid file.
        /// </summary>
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetConfigurationWithInvalidFile()
        {
            ConfigReader.GetConfiguration(@".\Resource\NonExisting.config");
        }

        /// <summary>
        ///   The get list violation file.
        /// </summary>
        [Test]
        public void GetListViolationFile()
        {
            MergeAndStyleConfig mergeAndStyleConfig = ConfigReader.GetConfiguration(@".\Resource\Valid.config");

            Assert.AreNotEqual(0, mergeAndStyleConfig.ViolationFiles.Count);
        }

        /// <summary>
        ///   The get list violation file with bad.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void GetListViolationFileWithBad()
        {
            ConfigReader.GetConfiguration(@".\Resource\BadStyleCopFileName.config");
        }

        /// <summary>
        ///   The get list violation file with empty.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void GetListViolationFileWithEmpty()
        {
            ConfigReader.GetConfiguration(@".\Resource\EmptyStyleCopFileName.config");
        }

        /// <summary>
        ///   The get list violation file with no.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void GetListViolationFileWithNo()
        {
            ConfigReader.GetConfiguration(@".\Resource\NoStyleCopFileName.config");
        }

        /// <summary>
        ///   The get merge file.
        /// </summary>
        [Test]
        public void GetMergeFile()
        {
            MergeAndStyleConfig mergeAndStyleConfig = ConfigReader.GetConfiguration(@".\Resource\Valid.config");

            Assert.IsNotNullOrEmpty(mergeAndStyleConfig.MergeFileName);
        }

        /// <summary>
        ///   The get merge file with bad directory name.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMergeFileWithBadDirectoryName()
        {
            ConfigReader.GetConfiguration(@".\Resource\BadDirectoryNameMergeFileName.config");
        }

        /// <summary>
        ///   The get merge file with bad file name.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMergeFileWithBadFileName()
        {
            ConfigReader.GetConfiguration(@".\Resource\BadFileNameMergeFileName.config");
        }

        /// <summary>
        ///   The get merge file with empty.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void GetMergeFileWithEmpty()
        {
            ConfigReader.GetConfiguration(@".\Resource\EmptyMergeFileName.config");
        }

        /// <summary>
        ///   The get merge file with no.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void GetMergeFileWithNo()
        {
            ConfigReader.GetConfiguration(@".\Resource\NoMergeFileName.config");
        }

        #endregion
    }
}