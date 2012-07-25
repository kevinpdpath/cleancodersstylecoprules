// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameHasNonEnglishCharacter.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   StyleCop custom rule that validates if a name has non english characters in it.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Rule
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using CleanCodersStyleCopRules.Common;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   StyleCop custom rule that validates if a name has non english characters in it.
    /// </summary>
    public static class NameHasNonEnglishCharacter
    {
        #region Public Properties

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
        /// Validate if a name has non english characters in it.
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

            ProcessName(element, element.Declaration.Name, element.LineNumber, context);

            foreach (Field field in element.ChildCodeElements.OfType<Field>().ToList())
            {
                ProcessName(element, field.Declaration.Name, field.LineNumber, context);
            }

            foreach (Delegate delegateObject in element.ChildCodeElements.OfType<Delegate>().ToList())
            {
                ParseDelegate(delegateObject, context);
            }

            foreach (Event eventObject in element.ChildCodeElements.OfType<Event>().ToList())
            {
                ParseEvent(eventObject, context);
            }

            foreach (Property property in element.ChildCodeElements.OfType<Property>().ToList())
            {
                ProcessName(element, property.Declaration.Name, property.LineNumber, context);
            }

            foreach (Constructor constructor in element.ChildCodeElements.OfType<Constructor>().ToList())
            {
                ParseConstructor(constructor, context);
            }

            foreach (Method method in element.ChildCodeElements.OfType<Method>().ToList())
            {
                ParseMethod(method, context);
            }

            foreach (Struct structObject in element.ChildCodeElements.OfType<Struct>().ToList())
            {
                ParseStruct(structObject, context);
            }

            foreach (Enum enumObject in element.ChildCodeElements.OfType<Enum>().ToList())
            {
                ParseEnum(enumObject, context);
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse a constructor and the names of its parameters.
        /// </summary>
        /// <param name="constructor">
        /// The constructor. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        private static void ParseConstructor(Constructor constructor, CleanCoderAnalyzer context)
        {
            ProcessName(constructor, constructor.Declaration.Name, constructor.LineNumber, context);

            foreach (Parameter parameter in constructor.Parameters.ToList())
            {
                ProcessName(constructor, parameter.Name, parameter.LineNumber, context);
            }
        }

        /// <summary>
        /// Parse a delegate and the names of its parameters.
        /// </summary>
        /// <param name="delegateObject">
        /// The delegate. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        private static void ParseDelegate(Delegate delegateObject, CleanCoderAnalyzer context)
        {
            ProcessName(delegateObject, delegateObject.Declaration.Name, delegateObject.LineNumber, context);

            foreach (Parameter parameter in delegateObject.Parameters.ToList())
            {
                ProcessName(delegateObject, parameter.Name, parameter.LineNumber, context);
            }
        }

        /// <summary>
        /// Parse an enum and the names of its enum items.
        /// </summary>
        /// <param name="enumObject">
        /// The enum. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        private static void ParseEnum(Enum enumObject, CleanCoderAnalyzer context)
        {
            ProcessName(enumObject, enumObject.Declaration.Name, enumObject.LineNumber, context);

            foreach (EnumItem enumItem in enumObject.ChildCodeElements.OfType<EnumItem>().ToList())
            {
                ProcessName(enumObject, enumItem.Declaration.Name, enumItem.LineNumber, context);
            }
        }

        /// <summary>
        /// Parse and event, including its type.
        /// </summary>
        /// <param name="eventObject">
        /// The event. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        private static void ParseEvent(Event eventObject, CleanCoderAnalyzer context)
        {
            ProcessName(eventObject, eventObject.Declaration.Name, eventObject.LineNumber, context);

            ProcessName(eventObject, eventObject.EventHandlerType.Text, eventObject.LineNumber, context);
        }

        /// <summary>
        /// Parse method and the names of its argument and its variables.
        /// </summary>
        /// <param name="method">
        /// The method. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0309:DescriptiveNameTooExplicit", Justification = "It's for a test.")]
        private static void ParseMethod(Method method, CleanCoderAnalyzer context)
        {
            string methodName = Utility.TrimGenericType(method.Declaration.Name);

            ProcessName(method, methodName, method.LineNumber, context);

            foreach (Parameter parameter in method.Parameters.ToList())
            {
                ProcessName(method, parameter.Name, parameter.LineNumber, context);
            }

            foreach (Variable variable in method.Variables.ToList())
            {
                ProcessName(method, variable.Name, variable.LineNumber, context);
            }
        }

        /// <summary>
        /// Parse a struct and the names of its parameters.
        /// </summary>
        /// <param name="structObject">
        /// The struct. 
        /// </param>
        /// <param name="context">
        /// The context. 
        /// </param>
        private static void ParseStruct(Struct structObject, CleanCoderAnalyzer context)
        {
            ProcessName(structObject, structObject.Declaration.Name, structObject.LineNumber, context);

            foreach (Field field in structObject.ChildCodeElements.OfType<Field>().ToList())
            {
                ProcessName(structObject, field.Declaration.Name, field.LineNumber, context);
            }

            foreach (Constructor constructor in structObject.ChildCodeElements.OfType<Constructor>().ToList())
            {
                ParseConstructor(constructor, context);
            }
        }

        /// <summary>
        /// Validate if a name has non english characters in it.
        /// </summary>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="name">
        /// The variable name. 
        /// </param>
        /// <param name="lineNumber">
        /// The line number where the variable apperas. 
        /// </param>
        /// <param name="context">
        /// The context, this class. 
        /// </param>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "It's a delegate for Analyzer.VisitElement.")]
        private static void ProcessName(CsElement element, string name, int lineNumber, CleanCoderAnalyzer context)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(name, "name");
            Param.AssertNotNull(lineNumber, "lineNumber");
            Param.AssertNotNull(context, "context");

            Regex englishOnlyRegex = new Regex("^[0-9A-Za-z_.]+$");

            if (englishOnlyRegex.IsMatch(name) == false)
            {
                context.AddViolation(element, lineNumber, RuleName, name);
            }
        }

        #endregion
    }
}