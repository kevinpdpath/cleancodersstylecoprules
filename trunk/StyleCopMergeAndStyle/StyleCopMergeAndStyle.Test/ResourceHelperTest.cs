// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceHelperTest.cs" company="CGI">
//   Copyright (c) CGI. All rights reserved.
// </copyright>
// <summary>
//   The resource helper test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopMergeAndStyle.Test
{
    using System;
    using System.IO;

    using NUnit.Framework;

    /// <summary>
    /// The resource helper test.
    /// </summary>
    [TestFixture]
    public class ResourceHelperTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// The write embedded resource to file.
        /// </summary>
        [Test]
        public void WriteEmbeddedResourceToFile()
        {
            string[] resourceNames = typeof(ResourceHelper).Assembly.GetManifestResourceNames();

            foreach (string resourceName in resourceNames)
            {
                string outputFile = @".\" + resourceName;

                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }

                ResourceHelper.WriteEmbeddedResourceToFile(typeof(ResourceHelper).Assembly, resourceName.Replace(typeof(ResourceHelper).Assembly.GetName().Name + ".", string.Empty), outputFile);

                Assert.IsTrue(File.Exists(outputFile));

                File.Delete(outputFile);
            }
        }

        /// <summary>
        /// The write embedded resource to file with bad resource name.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void WriteEmbeddedResourceToFileWithBadResourceName()
        {
            ResourceHelper.WriteEmbeddedResourceToFile(typeof(ResourceHelper).Assembly, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }

        #endregion
    }
}