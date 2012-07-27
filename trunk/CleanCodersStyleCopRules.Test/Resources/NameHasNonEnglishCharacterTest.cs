// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameHasNonEnglishCharacterTest.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Dummy class to unit test the NameHasNonEnglishCharacter custom StyleCop rule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules.Test.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    ///   Dummy class to unit test the NameHasNonEnglishCharacter custom StyleCop rule.
    /// </summary>
    public class NameHasNonEnglishCharacterTest
    {
        #region Constants

        /// <summary>
        ///   The nom complet ville québec.
        /// </summary>
        public const string NomCompletVilleQuébec = "Ville de Québec";

        #endregion

        #region Fields

        /// <summary>
        ///   The près.
        /// </summary>
        private bool près;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NameHasNonEnglishCharacterTest"/> class.
        /// </summary>
        /// <param name="près">
        /// The près.
        /// </param>
        public NameHasNonEnglishCharacterTest(bool près)
        {
            this.près = près;
        }

        #endregion

        #region Delegates

        /// <summary>
        ///   The hôtel handler.
        /// </summary>
        /// <param name="envoyéPar"> The sender. </param>
        /// <param name="eventArgs"> The event args. </param>
        public delegate void HôtelHandler(object envoyéPar, EventArgs eventArgs);

        #endregion

        #region Public Events

        /// <summary>
        ///   The ÉvènementHôtel event.
        /// </summary>
        public event HôtelHandler ÉvènementHôtel;

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets a value indicating whether accès.
        /// </summary>
        public bool Accès { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The arrêter.
        /// </summary>
        /// <param name="numeroArrêt">
        /// The numero Arrêt.
        /// </param>
        public void Arrêter(int numeroArrêt)
        {
            bool mêmeCouleur = true;

            List<string> someLists = new List<string>();

            Console.WriteLine(mêmeCouleur.ToString(CultureInfo.InvariantCulture) + " " + someLists.Count);
        }

        /// <summary>
        /// The get liste arrêts.
        /// </summary>
        /// <param name="nomÎlot">
        /// The nom Îlot. 
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; System.String]. 
        /// </returns>
        public List<string> GetListeArrêts(string nomÎlot)
        {
            return new List<string>();
        }

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="annéePassée">
        /// The année Passée. 
        /// </param>
        public void Process(int annéePassée)
        {
            const string Whoops = "hola";

            string flag = "abc";

            Console.WriteLine(flag + Whoops);
        }

        #endregion
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="Coordonnée" /> struct.
    /// </summary>
    public struct Coordonnée
    {
        #region Fields

        /// <summary>
        ///   The coordinate x.
        /// </summary>
        public int CoordonnéeX;

        /// <summary>
        ///   The coordinate y.
        /// </summary>
        public int CoordonnéeY;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordonnée"/> struct.
        /// </summary>
        /// <param name="coordonnéeX">
        /// The coordinate X. 
        /// </param>
        /// <param name="coordonnéeY">
        /// The coordinate Y. 
        /// </param>
        public Coordonnée(int coordonnéeX, int coordonnéeY)
        {
            this.CoordonnéeX = coordonnéeX;
            this.CoordonnéeY = coordonnéeY;
        }

        #endregion
    }

    /// <summary>
    ///   The journée.
    /// </summary>
    public enum Journée
    {
        /// <summary>
        ///   The lundi.
        /// </summary>
        Lundi, 

        /// <summary>
        ///   The mardi.
        /// </summary>
        Mardi, 

        /// <summary>
        ///   The mercredi.
        /// </summary>
        Mercredi, 

        /// <summary>
        ///   The jeudi.
        /// </summary>
        Jeudi, 

        /// <summary>
        ///   The vendredi.
        /// </summary>
        Vendredi, 

        /// <summary>
        ///   The samedi.
        /// </summary>
        Samedi, 

        /// <summary>
        ///   The congé.
        /// </summary>
        Congé
    }

    /// <summary>
    ///   The français.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It's for a test.")]
    public class Français : IFrançais
    {
        #region Public Methods and Operators

        /// <summary>
        ///   The sample method.
        /// </summary>
        /// <exception cref="NotImplementedException">Some text here.</exception>
        public void Sample()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    ///   The Français interface.
    /// </summary>
    public interface IFrançais
    {
        #region Public Methods and Operators

        /// <summary>
        ///   The sample method.
        /// </summary>
        void Sample();

        #endregion
    }

    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="T">
    /// The class type.
    /// </typeparam>
    public class Repository<T> where T : class
    {
        /// <summary>
        /// The some test.
        /// </summary>
        private string someTest;
    }
}