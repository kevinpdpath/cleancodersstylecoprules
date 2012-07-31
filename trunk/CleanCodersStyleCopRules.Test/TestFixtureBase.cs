// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestFixtureBase.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Base class for all TestFixture testing StyleCop custom rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using NUnit.Framework;

    using StyleCop;

    /// <summary>
    /// Base class for all TestFixture testing StyleCop custom rules.
    /// </summary>
    [TestFixture]
    public abstract class TestFixtureBase
    {
        #region Constants and Fields

        /// <summary>
        ///   The code project.
        /// </summary>
        private CodeProject codeProject;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "TestFixtureBase" /> class.
        /// </summary>
        protected TestFixtureBase()
        {
            string settings = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Settings.StyleCop";

            List<string> addInPaths = new List<string> { AppDomain.CurrentDomain.BaseDirectory };

            this.StyleCopConsole = new StyleCopConsole(settings, false, null, addInPaths, true);

            this.StyleCopConsole.ViolationEncountered += (sender, args) => this.StyleCopViolations.Add(args.Violation);

            this.StyleCopConsole.OutputGenerated += (sender, args) => this.StyleCopOutput.Add(args.Output);
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the StyleCop output.
        /// </summary>
        protected List<string> StyleCopOutput { get; private set; }

        /// <summary>
        ///   Gets the StyleCop violations.
        /// </summary>
        protected List<Violation> StyleCopViolations { get; private set; }

        /// <summary>
        ///   Gets or sets the StyleCop Console.
        /// </summary>
        private StyleCopConsole StyleCopConsole { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Configure the CodeProject.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.StyleCopViolations = new List<Violation>();

            this.StyleCopOutput = new List<string>();

            string settings = AppDomain.CurrentDomain.BaseDirectory + @"\Resources";

            Configuration configuration = new Configuration(new string[0]);

            this.codeProject = new CodeProject(Guid.NewGuid().GetHashCode(), settings, configuration);
        }

        /// <summary>
        /// Clean up the test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.codeProject = null;

            this.StyleCopViolations.Clear();

            this.StyleCopOutput.Clear();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Analyzes the code file.
        /// </summary>
        /// <param name="sourceCodeFileName">
        /// The code file name (file name with extention, not the full path. File must be located in the Resources directory)
        /// </param>
        /// <param name="numberOfExpectedViolation">
        /// The number of expected violations.
        /// </param>
        protected void AnalyzeCodeWithAssertion(string sourceCodeFileName, int numberOfExpectedViolation)
        {
            this.AddSourceCode(sourceCodeFileName);

            this.StartAnalysis();

            this.WriteViolationsToConsole();

            this.WriteOutputToConsole();

            Assert.AreEqual(numberOfExpectedViolation, this.StyleCopViolations.Count);
        }

        /// <summary>
        /// The write violations to console.
        /// </summary>
        protected void WriteViolationsToConsole()
        {
            foreach (Violation violation in this.StyleCopViolations)
            {
                Console.WriteLine(violation.Message);
            }
        }

        /// <summary>
        /// Dynamically add a source file to test.
        /// </summary>
        /// <param name="sourceCodeFileName">
        /// The file name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Occurs if the file could not be loaded from the Resources directory.
        /// </exception>
        private void AddSourceCode(string sourceCodeFileName)
        {
            string fullSourceCodeFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\" + sourceCodeFileName;

            bool result = this.StyleCopConsole.Core.Environment.AddSourceCode(this.codeProject, fullSourceCodeFilePath, null);

            if (result == false)
            {
                throw new ArgumentException("Source code file could not be loaded.", sourceCodeFileName);
            }
        }

        /// <summary>
        /// Starts the analysis of the code file with StyleCop.
        /// </summary>
        private void StartAnalysis()
        {
            CodeProject[] projects = new[] { this.codeProject };

            bool result = this.StyleCopConsole.Start(projects, true);

            if (result == false)
            {
                throw new ArgumentException("StyleCopConsole.Start had a problem.");
            }
        }

        /// <summary>
        /// The write output to console.
        /// </summary>
        private void WriteOutputToConsole()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this.StyleCopOutput.ToArray()));
        }

        #endregion
    }
}