// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodHasBooleanParameter.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// StyleCop custom rule that validates if a method has boolean parameters.
    /// </summary>
    public class MethodHasBooleanParameter : CustomRuleBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodHasBooleanParameter"/> class.
        /// </summary>
        public MethodHasBooleanParameter()
        {
            this.ElementTypes.Add(ElementType.Method);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the rule name.
        /// </summary>
        public override string RuleName
        {
            get
            {
                return MethodBase.GetCurrentMethod().ReflectedType.Name;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Validate if a method has boolean parameters with an element.
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
        public override bool ValidateElement(CsElement element, CsElement parentElement, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(context, "context");

            Method method = element as Method;

            if (method == null)
            {
                return true;
            }

            if (Utility.HasDllImportAttribute(method))
            {
                return true;
            }

            foreach (Parameter parameter in method.Parameters)
            {
                string parameterTypeName = parameter.Type.ToString();

                if (parameterTypeName.StartsWith("bool", true, CultureInfo.InvariantCulture) && (method.Declaration.Name != "Dispose"))
                {
                    context.AddViolation(method, method.LineNumber, this.RuleName, method.Declaration.Name, parameter.Name);
                }
            }

            return true;
        }

        #endregion
    }
}