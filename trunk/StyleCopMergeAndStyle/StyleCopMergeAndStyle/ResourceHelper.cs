// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceHelper.cs" company="CGI">
//   Copyright (c) CGI. All rights reserved.
// </copyright>
// <summary>
//   Helper class to manage resources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopMergeAndStyle
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Helper class to manage resources.
    /// </summary>
    public static class ResourceHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Extract an embedded resource and write it to a file.
        /// </summary>
        /// <param name="targetAssembly">
        /// The target assembly.
        /// </param>
        /// <param name="resourceName">
        /// The resource name.
        /// </param>
        /// <param name="filepath">
        /// The output file path.
        /// </param>
        /// <exception cref="Exception">
        /// Thrown if a resource cannot be found.
        /// </exception>
        public static void WriteEmbeddedResourceToFile(Assembly targetAssembly, string resourceName, string filepath)
        {
            using (Stream stream = targetAssembly.GetManifestResourceStream(targetAssembly.GetName().Name + "." + resourceName))
            {
                if (stream == null)
                {
                    throw new ApplicationException(string.Format("Cannot find embedded resource: [{0}]", resourceName));
                }

                byte[] bytes = new byte[stream.Length];

                stream.Read(bytes, 0, bytes.Length);

                using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(filepath, FileMode.Create)))
                {
                    binaryWriter.Write(bytes);
                }
            }
        }

        #endregion
    }
}