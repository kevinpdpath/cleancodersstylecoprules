// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViolationMerger.cs" company="CGI">
//   Copyright (c) CGI. All rights reserved.
// </copyright>
// <summary>
//   The violation merger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopMergeAndStyle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// The violation merger.
    /// </summary>
    public static class ViolationMerger
    {
        #region Public Methods and Operators

        /// <summary>
        /// Initializes a new instance of the <see cref="ViolationMerger"/> class.
        /// </summary>
        /// <param name="violationFileNames">
        /// The violation file names. 
        /// </param>
        /// <returns>
        /// The merged violations. 
        /// </returns>
        public static string Merge(List<string> violationFileNames)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<StyleCopViolations>");

            foreach (string fileName in violationFileNames)
            {
                XDocument document = ReadViolationFile(fileName);

                IEnumerable<XElement> elementViolations = from i in document.Descendants("Violation") select i;

                foreach (XElement elementViolation in elementViolations)
                {
                    stringBuilder.AppendLine(elementViolation.ToString());
                }
            }

            stringBuilder.AppendLine("</StyleCopViolations>");

            return stringBuilder.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Read the violation file.
        /// </summary>
        /// <param name="violationFilePath">
        /// The path to the configuration file. 
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Exception thrown is the file does not exist or is not accessible.
        /// </exception>
        /// <returns>
        /// An XDocument representing the entire violation file. 
        /// </returns>
        private static XDocument ReadViolationFile(string violationFilePath)
        {
            if (File.Exists(violationFilePath) == false)
            {
                throw new FileNotFoundException(string.Format("File {0} cannot be found or read.", violationFilePath));
            }

            return XDocument.Load(violationFilePath);
        }

        #endregion
    }
}