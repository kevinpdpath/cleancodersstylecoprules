// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utility.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Commonly shared static utilities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   Commonly shared static utilities.
    /// </summary>
    public static class Utility
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get the first child of the element.
        /// </summary>
        /// <param name="element">
        /// The element. 
        /// </param>
        /// <param name="skipElementTypes">
        /// The list of ElementTypes to skip when looking for the first child. 
        /// </param>
        /// <returns>
        /// The CsElement child, null if nothing is found. 
        /// </returns>
        public static CsElement GetFirstChildOfElement(CsElement element, List<ElementType> skipElementTypes)
        {
            Param.AssertNotNull(element, "element");

            CsElement firstChild = null;

            foreach (CsElement childElement in element.ChildElements)
            {
                if (skipElementTypes != null && skipElementTypes.Contains(childElement.ElementType))
                {
                    continue;
                }

                firstChild = childElement;

                break;
            }

            return firstChild;
        }

        /// <summary>
        /// Valdiates if the declaration contans the keyword "partial".
        /// </summary>
        /// <param name="declaration">
        /// The declaration. 
        /// </param>
        /// <returns>
        /// True if the keyword "partial" is found, False otherwise. 
        /// </returns>
        public static bool IsDeclarationPartial(Declaration declaration)
        {
            Param.AssertNotNull(declaration, "declaration");

            return declaration.Tokens.Any(token => token.Text.Equals("partial", StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Determine if a variable type is some type of matrix.
        /// </summary>
        /// <remarks>
        /// This is far from being perfect. It is not going to catch everything, far from it. But at least, it gets the basic ones.
        /// </remarks>
        /// <param name="variableTypeDefinition">
        /// The variable type definition. 
        /// </param>
        /// <returns>
        /// True if the variable represents a matrix, otherwise False. 
        /// </returns>
        public static bool IsSomeKindOfMatrix(string variableTypeDefinition)
        {
            Param.AssertValidString(variableTypeDefinition, "variableTypeDefinition");

            if (variableTypeDefinition.Trim().Equals("void"))
            {
                return false;
            }

            variableTypeDefinition = TrimNamespace(variableTypeDefinition);

            variableTypeDefinition = TrimGenericType(variableTypeDefinition);

            List<string> matricies = new List<string>
                {
                    "ArrayList", 
                    "BitArray", 
                    "BitVector32", 
                    "Collection", 
                    "Dictionary", 
                    "HashSet", 
                    "Hashtable", 
                    "HybridDictionary", 
                    "ICollection", 
                    "IDictionary", 
                    "IEnumerable", 
                    "IList", 
                    "IOrderedDictionary", 
                    "KeyedCollection", 
                    "LinkedList", 
                    "List", 
                    "ListDictionary", 
                    "NameValueCollection", 
                    "OrderedDictionary", 
                    "Queue", 
                    "ReadOnlyCollection", 
                    "SortedDictionary", 
                    "SortedList", 
                    "Stack", 
                    "StringCollection", 
                    "StringDictionary"
                };

            if (variableTypeDefinition.Contains("[") || matricies.Contains(variableTypeDefinition) || variableTypeDefinition.Contains("Collection") || variableTypeDefinition.Contains("Array"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified method has the DLL import attribute.
        /// </summary>
        /// <param name="method">
        /// The method. 
        /// </param>
        /// <returns>
        /// Returns True if the specified method has the DLL import attribute; otherwise, False. 
        /// </returns>
        public static bool HasDllImportAttribute(Method method)
        {
            Param.AssertNotNull(method, "method");

            return method.Attributes.Any(attribute => attribute.Text.Contains("DllImport"));
        }

        /// <summary>
        /// Split the source code in a list of lines.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code. 
        /// </param>
        /// <returns>
        /// A list of strings, where each item in the list is a line of code. 
        /// </returns>
        public static List<string> SplitSourceCodeInLine(SourceCode sourceCode)
        {
            string source;

            using (TextReader reader = sourceCode.Read())
            {
                source = reader.ReadToEnd();
            }

            return new List<string>(source.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
        }

        /// <summary>
        /// Split a camel case string at the upper case letter, so that each part starts with an upper case, except the first part of course.
        /// </summary>
        /// <param name="camelCaseValue">
        /// The camel case value. 
        /// </param>
        /// <returns>
        /// The System.String[]. 
        /// </returns>
        public static string[] SplitStringAtUpperCaseLetter(string camelCaseValue)
        {
            return Regex.Replace(camelCaseValue, "([A-Z])", " $1", RegexOptions.Compiled).Trim().Split(' ');
        }

        /// <summary>
        /// Trim generic type definition from the type.
        /// </summary>
        /// <param name="identifier">
        /// The identifier. 
        /// </param>
        /// <returns>
        /// The type without the generics markup. 
        /// </returns>
        public static string TrimGenericType(string identifier)
        {
            string result = identifier;

            int startOfGenericTypeParameters = identifier.IndexOf("<", StringComparison.InvariantCultureIgnoreCase);
            if (startOfGenericTypeParameters > 0)
            {
                result = identifier.Substring(0, startOfGenericTypeParameters);
            }

            return result;
        }

        /// <summary>
        /// Trim the namespace in a variable type definition.
        /// </summary>
        /// <param name="variableTypeWithNameSpace">
        /// The identifier. 
        /// </param>
        /// <returns>
        /// The variable type without its namespace prefix. 
        /// </returns>
        public static string TrimNamespace(string variableTypeWithNameSpace)
        {
            string result = variableTypeWithNameSpace;

            if (variableTypeWithNameSpace.Trim().Contains("."))
            {
                result = variableTypeWithNameSpace.Substring(variableTypeWithNameSpace.LastIndexOf(".", StringComparison.InvariantCultureIgnoreCase) + 1);
            }

            return result;
        }

        #endregion
    }
}