// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCopMergeAndStyle
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Text;

    using Nini.Config;

    using StyleCopMergeAndStyle.Struct;

    /// <summary>
    ///   Merge StyleCop Violations file and add a style sheed to the result.
    /// </summary>
    public class Program
    {
        #region Static Fields

        /// <summary>
        ///   Usage displayed when no arguments are provided.
        /// </summary>
        private static readonly string ConfigUsage = Environment.NewLine + "{0} /c path" + Environment.NewLine + Environment.NewLine + "Where:" + Environment.NewLine + Environment.NewLine
                                                     + "/c\t Specify the full or relative path to a configuration file" + Environment.NewLine + Environment.NewLine + Environment.NewLine + "Example: "
                                                     + Environment.NewLine + Environment.NewLine + @"{0} /c "".\sample.config""" + Environment.NewLine + Environment.NewLine;

        #endregion

        #region Methods

        /// <summary>
        /// Starting point of the program.
        /// </summary>
        /// <param name="args">
        /// Arguments of the program. 
        /// </param>
        /// <returns>
        /// 0 when successful, a negative number to show failure. 
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0034:MethodContainsTooManyLine", Justification = "Can't be split up.")]
        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(string.Format(ConfigUsage, Assembly.GetExecutingAssembly().ManifestModule.Name));
                return -1;
            }

            StringBuilder requiredArgs = new StringBuilder();

            ArgvConfigSource source = new ArgvConfigSource(args);
            source.AddSwitch("item", "configFilePath", "c");

            string configFilePath = source.Configs["item"].Get("configFilePath");

            if (string.IsNullOrEmpty(configFilePath))
            {
                requiredArgs.AppendLine("Missing manquant, please sepcify /c");
            }

            if (string.IsNullOrEmpty(configFilePath) == false && File.Exists(configFilePath) == false)
            {
                requiredArgs.AppendLine("Invalid argument /c, the file does not exist.");
            }

            if (requiredArgs.ToString().Length > 0)
            {
                Console.WriteLine(string.Format("{1}{0}:{1}{2}", Assembly.GetExecutingAssembly().ManifestModule.Name, Environment.NewLine, requiredArgs));
                return -1;
            }

            try
            {
                MergeAndStyleConfig mergeAndStyleConfig = ConfigReader.GetConfiguration(configFilePath);

                string mergedValidation = ViolationMerger.Merge(mergeAndStyleConfig.ViolationFiles);

                string headerXslt = string.Format(@"<?xml version=""1.0"" encoding=""ISO-8859-1""?>{0}<?xml-stylesheet type=""text/xsl"" href=""{1}""?>{0}", Environment.NewLine, "StyleCopReport.xsl");

                File.WriteAllText(mergeAndStyleConfig.MergeFileName, headerXslt + mergedValidation);

                string outputDirectory = Path.GetDirectoryName(mergeAndStyleConfig.MergeFileName);

                if (string.IsNullOrEmpty(outputDirectory))
                {
                    outputDirectory = @".\";
                }

                WriteAllEmbeddedResourceToFile(outputDirectory);

                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occured: {0}", exception.Message);
                return -1;
            }
        }

        /// <summary>
        /// The write all embedded resource to file.
        /// </summary>
        /// <param name="outputDirectory">
        /// The output directory. 
        /// </param>
        private static void WriteAllEmbeddedResourceToFile(string outputDirectory)
        {
            string[] resourceNames = typeof(ResourceHelper).Assembly.GetManifestResourceNames();

            foreach (string resourceName in resourceNames)
            {
                string resourceNameWithoutAssemblyName = resourceName.Replace(typeof(ResourceHelper).Assembly.GetName().Name + ".", string.Empty);

                string outputFile = outputDirectory + @"\" + resourceNameWithoutAssemblyName.Replace("EmbeddedResource.", string.Empty);

                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }

                ResourceHelper.WriteEmbeddedResourceToFile(typeof(ResourceHelper).Assembly, resourceNameWithoutAssemblyName, outputFile);
            }
        }

        #endregion
    }
}