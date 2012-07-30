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
    /// <summary>
    /// Dummy class to unit test the VariableNameIsNotPlural custom StyleCop rule.
    /// </summary>
    public class VariableNameIsNotPluralTest
    {
        #region Constants and Fields

        /// <summary>
        ///   The color array.
        /// </summary>
        private string[] color;

        /// <summary>
        ///   The array list.
        /// </summary>
        private System.Collections.ArrayList light;

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
            int[] gougou;
            System.Collections.ArrayList arrayList;
            System.Collections.BitArray bitArray;
            System.Collections.Hashtable hashtable;
            System.Collections.ICollection collectionInterface;
            System.Collections.IDictionary dictionaryInterface;
            System.Collections.IList listInterface;
            System.Collections.Queue queue;
            System.Collections.SortedList sortedList;
            System.Collections.ObjectModel.Collection<int> collectionInt;
            System.Collections.ObjectModel.KeyedCollection<string, string> keyedCollectionInt;
            System.Collections.ObjectModel.ReadOnlyCollection<string> readOnlyCollection;
            System.Collections.Specialized.BitVector32 bitVector32;
            System.Collections.Specialized.HybridDictionary hybridDictionary;
            System.Collections.Specialized.IOrderedDictionary orderedDictionaryInterface;
            System.Collections.Specialized.ListDictionary listDictionary;
            System.Collections.Specialized.NameValueCollection nameValueCollection;
            System.Collections.Specialized.OrderedDictionary orderedDictionary;
            System.Collections.Specialized.StringCollection stringCollection;
            System.Collections.Specialized.StringDictionary stringDictionary;
            System.Collections.Generic.Dictionary<string, string> dictionaryGeneric;
            System.Collections.Generic.HashSet<string> hashSet;
            System.Collections.Generic.ICollection<string> collectionInterfaceGeneric;
            System.Collections.Generic.IDictionary<string, string> dictionaryInterfaceGeneric;
            System.Collections.Generic.IEnumerable<string> enumerableInterfaceGeneric;
            System.Collections.Generic.IList<string> listInterfaceGeneric;
            System.Collections.Generic.LinkedList<string> linkeyListGeneric;
            System.Collections.Generic.List<string> listGeneric;
            System.Collections.Generic.Queue<string> queueGeneric;
            System.Collections.Generic.SortedDictionary<string, string> sortedDictionaryGeneric;
            System.Collections.Generic.SortedList<string, string> sortedListGeneric;
            System.Collections.Generic.Stack<string> stackGeneric;
        }

        #endregion
    }
}