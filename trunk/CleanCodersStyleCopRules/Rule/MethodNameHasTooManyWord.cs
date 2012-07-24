﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodNameHasTooManyWord.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a the method name contains too many words.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if a the method name contains too many words.
    /// </summary>
    public static class MethodNameHasTooManyWord
    {
        #region Public Properties

        /// <summary>
        ///   Gets the property setting name.
        /// </summary>
        public static string PropertySettingName
        {
            get
            {
                return MethodBase.GetCurrentMethod().ReflectedType.Name + "Value";
            }
        }

        /// <summary>
        ///   Gets the rule name.
        /// </summary>
        public static string RuleName
        {
            get
            {
                return MethodBase.GetCurrentMethod().ReflectedType.Name;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Validate if a the method name contains too many words.
        /// </summary>
        /// <param name="element">
        /// The current element. 
        /// </param>
        /// <param name="parentElement">
        /// The parent element. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        /// <returns>
        /// Returns true to continue, false to stop visiting the elements in the code document. 
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        public static bool Validate(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(context, "context");

            string[] methodNameParts = Utility.SplitStringAtUpperCaseLetter(element.Declaration.Name);

            if (methodNameParts.Length > (int)context.AnalyserSetting[PropertySettingName])
            {
                context.AddViolation(element, element.LineNumber, RuleName, element.Declaration.Name, methodNameParts.Length, context.AnalyserSetting[PropertySettingName]);
            }

            return true;
        }

        #endregion
    }
}