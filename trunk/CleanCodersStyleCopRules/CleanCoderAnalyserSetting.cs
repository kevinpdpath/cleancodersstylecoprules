// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CleanCoderAnalyserSetting.cs" company="None, it's free for all.">
//   Copyright (c) None, it's free for all. All rights reserved.
// </copyright>
// <summary>
//   Reads the StyleCop.settings and expose the property settings found as properties.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCodersStyleCopRules
{
    using System.Collections.Generic;

    using CleanCodersStyleCopRules.Rule;

    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    ///   Reads the StyleCop.settings and expose the property settings found as properties.
    /// </summary>
    /// <remarks>
    ///   This class properties run in a fail safe mode, if no property settings are found in the StyleCop.Settings file, default values will be used.
    /// </remarks>
    public class CleanCoderAnalyserSetting
    {
        #region Fields

        /// <summary>
        ///   The clean coder analyzer.
        /// </summary>
        private readonly CleanCoderAnalyzer cleanCoderAnalyzer;

        /// <summary>
        ///   The property setting dictionary.
        /// </summary>
        private readonly Dictionary<string, object> propertySettings = new Dictionary<string, object>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanCoderAnalyserSetting"/> class.
        /// </summary>
        /// <param name="cleanCoderAnalyzer">
        /// The clean coder analyzer. 
        /// </param>
        /// <param name="document">
        /// The document from which the settings will be read. 
        /// </param>
        public CleanCoderAnalyserSetting(CleanCoderAnalyzer cleanCoderAnalyzer, CsDocument document)
        {
            this.cleanCoderAnalyzer = cleanCoderAnalyzer;

            this.LoadDocumentSettings(document.Settings);
        }

        #endregion

        #region Public Indexers

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="index">
        /// The index. 
        /// </param>
        /// <returns>
        /// The object. 
        /// </returns>
        public object this[string index]
        {
            get
            {
                return this.propertySettings[index];
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Extract a property value from the Settings.StyleCop file.
        /// </summary>
        /// <typeparam name="T">
        /// The type of value to return. 
        /// </typeparam>
        /// <param name="settings">
        /// The settings for the document being parsed. 
        /// </param>
        /// <param name="propertyName">
        /// Name of the property to extract. 
        /// </param>
        /// <returns>
        /// Returns the templated type. 
        /// </returns>
        public T GetPropertySetting<T>(Settings settings, string propertyName)
        {
            Param.AssertNotNull(settings, "settings");
            Param.AssertValidString(propertyName, "propertyName");

            PropertyValue<T> property = this.cleanCoderAnalyzer.GetSetting(settings, propertyName) as PropertyValue<T>;

            if (property != null)
            {
                return property.Value;
            }

            PropertyDescriptor<T> propertyDescriptor = this.cleanCoderAnalyzer.PropertyDescriptors.GetPropertyDescriptor(propertyName) as PropertyDescriptor<T>;

            if (propertyDescriptor != null)
            {
                return propertyDescriptor.DefaultValue;
            }

            return default(T);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Extract a string property from the Settings.StyleCop file, and convert it to a List of string.
        /// </summary>
        /// <param name="settings">
        /// The settings for the document being parsed. 
        /// </param>
        /// <param name="propertyName">
        /// Name of the property to extract. 
        /// </param>
        /// <returns>
        /// Returns the list of values as a List, ensuring uniqueness of the values. 
        /// </returns>
        private List<string> GetStringPropertySettingAsList(Settings settings, string propertyName)
        {
            Param.AssertNotNull(settings, "settings");
            Param.AssertValidString(propertyName, "propertyName");

            string multipleItem = this.GetPropertySetting<string>(settings, propertyName);

            string[] multipleItems = multipleItem.Trim().Split(' ');

            List<string> propertyValues = new List<string>();

            if (multipleItems.Length > 0)
            {
                foreach (string value in multipleItems)
                {
                    if (string.IsNullOrEmpty(value) == false && propertyValues.Contains(value) == false)
                    {
                        propertyValues.Add(value);
                    }
                }
            }

            return propertyValues;
        }

        /// <summary>
        /// Load the settings from the StyleCop.settings file.
        /// </summary>
        /// <param name="settings">
        /// The settings for the document being parsed. 
        /// </param>
        /// <remarks>
        /// The settings will keep their default values if no configuration property is found in the StyleCop.settings file.
        /// </remarks>
        private void LoadDocumentSettings(Settings settings)
        {
            this.propertySettings.Add(ClassContainsTooManyLine.PropertySettingName, this.GetPropertySetting<int>(settings, ClassContainsTooManyLine.PropertySettingName));

            this.propertySettings.Add(ClassContainsTooManyMethod.PropertySettingName, this.GetPropertySetting<int>(settings, ClassContainsTooManyMethod.PropertySettingName));

            this.propertySettings.Add(ClassNameHasTooManyWord.PropertySettingName, this.GetPropertySetting<int>(settings, ClassNameHasTooManyWord.PropertySettingName));

            this.propertySettings.Add(LineContainsTrainWreck.PropertySettingName, this.GetPropertySetting<int>(settings, LineContainsTrainWreck.PropertySettingName));

            this.propertySettings.Add(LineIsTooLong.PropertySettingName, this.GetPropertySetting<int>(settings, LineIsTooLong.PropertySettingName));

            this.propertySettings.Add(MethodContainsTooManyLine.PropertySettingName, this.GetPropertySetting<int>(settings, MethodContainsTooManyLine.PropertySettingName));

            this.propertySettings.Add(MethodHasTooManyArgument.PropertySettingName, this.GetPropertySetting<int>(settings, MethodHasTooManyArgument.PropertySettingName));

            this.propertySettings.Add(VariableNameHasHungarianPrefix.PropertySettingName, this.GetStringPropertySettingAsList(settings, VariableNameHasHungarianPrefix.PropertySettingName));

            this.propertySettings.Add(VariableNameIsTooShort.PropertySettingName, this.GetPropertySetting<int>(settings, VariableNameIsTooShort.PropertySettingName));

            this.propertySettings.Add(PropertyContainsTooManyLine.PropertySettingName, this.GetPropertySetting<int>(settings, PropertyContainsTooManyLine.PropertySettingName));

            this.propertySettings.Add(TooManyComment.PropertySettingName, this.GetPropertySetting<int>(settings, TooManyComment.PropertySettingName));

            this.propertySettings.Add(MethodNameHasTooManyWord.PropertySettingName, this.GetPropertySetting<int>(settings, MethodNameHasTooManyWord.PropertySettingName));
        }

        #endregion
    }
}