// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigReader.cs" company="CGI">
//   Copyright (c) CGI. All rights reserved.
// </copyright>
// <summary>
//   The custom config reader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopMergeAndStyle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using StyleCopMergeAndStyle.Struct;

    /// <summary>
    /// The custom config reader.
    /// </summary>
    public static class ConfigReader
    {
        #region Public Methods and Operators

        /// <summary>
        /// Read the configuration file.
        /// </summary>
        /// <param name="configurationFilePath">
        /// The configuration file path, full or relative. 
        /// </param>
        /// <returns>
        /// Returns the configuration files. 
        /// </returns>
        public static MergeAndStyleConfig GetConfiguration(string configurationFilePath)
        {
            MergeAndStyleConfig result = new MergeAndStyleConfig();

            XDocument configurationDocument = ReadConfigurationFile(configurationFilePath);

            result.ViolationFiles = GetListViolationFile(configurationDocument);

            result.MergeFileName = GetMergeFile(configurationDocument);

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the list of StyleCop Violation files.
        /// </summary>
        /// <param name="configurationDocument">
        /// The configuration Document. 
        /// </param>
        /// <returns>
        /// A List of existing file names. 
        /// </returns>
        private static List<string> GetListViolationFile(XDocument configurationDocument)
        {
            List<string> violationFiles = new List<string>();

            IEnumerable<XElement> elementFileNames = from i in configurationDocument.Descendants("StyleCopFileName") select i;

            foreach (XElement elementFileName in elementFileNames)
            {
                if (string.IsNullOrEmpty(elementFileName.Value))
                {
                    continue;
                }

                string fileName = elementFileName.Value.Trim();

                if (File.Exists(fileName))
                {
                    violationFiles.Add(fileName);
                }
                else
                {
                    Console.WriteLine("File {0} does not exist.", fileName);
                }
            }

            if (violationFiles.Count == 0)
            {
                throw new ApplicationException("No valid StyleCopFileName found.");
            }

            return violationFiles;
        }

        /// <summary>
        /// Get the merge file name.
        /// </summary>
        /// <param name="configurationDocument">
        /// The configuration Document. 
        /// </param>
        /// <returns>
        /// The merge file name. 
        /// </returns>
        private static string GetMergeFile(XDocument configurationDocument)
        {
            XElement elementMergeFile = (from i in configurationDocument.Descendants("MergeFileName") select i).FirstOrDefault();

            if (elementMergeFile == null)
            {
                throw new ApplicationException("MergedFileName not found.");
            }

            string fullFileName = elementMergeFile.Value.Trim();

            string fileName = Path.GetFileName(fullFileName);

            if (string.IsNullOrEmpty(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new ApplicationException("Invalid MergedFileName.");
            }

            return fullFileName;
        }

        /// <summary>
        /// Read the configuration file.
        /// </summary>
        /// <param name="configurationFilePath">
        /// The path to the configuration file. 
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Exception thrown is the file does not exist or is not accessible.
        /// </exception>
        /// <returns>
        /// An XDocument representing the entire configuration file.. 
        /// </returns>
        private static XDocument ReadConfigurationFile(string configurationFilePath)
        {
            if (File.Exists(configurationFilePath) == false)
            {
                throw new FileNotFoundException(string.Format("File {0} cannot be found or read.", configurationFilePath));
            }

            return XDocument.Load(configurationFilePath);
        }

        #endregion
    }
}