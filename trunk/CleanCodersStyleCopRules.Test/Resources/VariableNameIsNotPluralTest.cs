// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableNameIsNotPluralTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the VariableNameIsTooShort custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    /// <summary>
    ///   Dummy class to unit test the VariableNameIsNotPlural custom StyleCop rule.
    /// </summary>
    public class VariableNameIsNotPluralTest
    {
        #region Fields

        /// <summary>
        ///   The color array.
        /// </summary>
        private string[] color;

        /// <summary>
        ///   The array list.
        /// </summary>
        private ArrayList light;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNameIsNotPluralTest"/> class.
        /// </summary>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <param name="light">
        /// The light.
        /// </param>
        public VariableNameIsNotPluralTest(string[] color, ArrayList light)
        {
            this.color = color;
            this.light = light;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Methods with errors.
        /// </summary>
        /// <param name="toto">
        /// The toto. 
        /// </param>
        public void WithErrors(int[] toto)
        {
            for (int i = 0; i < 10; i++)
            {
                int[] gougou = { 1, 2, 3 };

                Console.WriteLine("Hello there: {0}", gougou[0]);
            }

            ArrayList arrayList;
            BitArray bitArray;
            Hashtable hashtable;
            ICollection collectionInterface;
            IDictionary dictionaryInterface;
            IList listInterface;
            Queue queue;
            SortedList sortedList;
            Collection<int> collectionInt;
            KeyedCollection<string, string> keyedCollectionInt;
            ReadOnlyCollection<string> readOnlyCollection;
            BitVector32 bitVector32;
            HybridDictionary hybridDictionary;
            IOrderedDictionary orderedDictionaryInterface;
            ListDictionary listDictionary;
            NameValueCollection nameValueCollection;
            OrderedDictionary orderedDictionary;
            StringCollection stringCollection;
            StringDictionary stringDictionary;
            Dictionary<string, string> dictionaryGeneric;
            HashSet<string> hashSet;
            ICollection<string> collectionInterfaceGeneric;
            IDictionary<string, string> dictionaryInterfaceGeneric;
            IEnumerable<string> enumerableInterfaceGeneric;
            IList<string> listInterfaceGeneric;
            LinkedList<string> linkeyListGeneric;
            List<string> listGeneric;
            Queue<string> queueGeneric;
            SortedDictionary<string, string> sortedDictionaryGeneric;
            SortedList<string, string> sortedListGeneric;
            Stack<string> stackGeneric;
        }

        #endregion

        /// <summary>
        ///   The some container.
        /// </summary>
        public struct SomeContainer
        {
            #region Fields

            /// <summary>
            ///   The array list darkness.
            /// </summary>
            public ArrayList Darkness;

            /// <summary>
            ///   The array list light.
            /// </summary>
            public ArrayList Light;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="SomeContainer"/> struct.
            /// </summary>
            /// <param name="light">
            /// The light. 
            /// </param>
            /// <param name="darkness">
            /// The darkness. 
            /// </param>
            public SomeContainer(ArrayList light, ArrayList darkness)
            {
                this.Light = light;
                this.Darkness = darkness;
            }

            #endregion
        }
    }
}