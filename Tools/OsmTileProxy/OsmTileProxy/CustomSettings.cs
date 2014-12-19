// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomSettings.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy
{
    using System.Configuration;

    /// <summary>
    /// The custom settings.
    /// </summary>
    public static class CustomSettings
    {
        #region Public Properties

        /// <summary>
        /// Gets the bing maps key.
        /// </summary>
        public static string BingMapsKey
        {
            get
            {
                string value = ConfigurationManager.AppSettings["BingMapsKey"];

                return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            }
        }

        /// <summary>
        /// Gets the cache root directory.
        /// </summary>
        public static string CacheRootDirectory
        {
            get
            {
                string value = ConfigurationManager.AppSettings["CacheRootDirectory"];

                return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            }
        }

        /// <summary>
        /// Gets the google for work client id.
        /// </summary>
        public static string GoogleForWorkClientId
        {
            get
            {
                string value = ConfigurationManager.AppSettings["GoogleForWorkClientId"];

                return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            }
        }

        /// <summary>
        /// Gets the google for work private key.
        /// </summary>
        public static string GoogleForWorkPrivateKey
        {
            get
            {
                string value = ConfigurationManager.AppSettings["GoogleForWorkPrivateKey"];

                return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            }
        }

        /// <summary>
        /// Gets the google maps developer key.
        /// </summary>
        public static string GoogleMapsDeveloperKey
        {
            get
            {
                string value = ConfigurationManager.AppSettings["GoogleMapsDeveloperKey"];

                return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            }
        }

        /// <summary>
        /// Gets the here app code.
        /// </summary>
        public static string HereAppCode
        {
            get
            {
                string value = ConfigurationManager.AppSettings["HereAppCode"];

                return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            }
        }

        /// <summary>
        /// Gets the here app id.
        /// </summary>
        public static string HereAppId
        {
            get
            {
                string value = ConfigurationManager.AppSettings["HereAppId"];

                return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            }
        }

        /// <summary>
        /// Gets a value indicating whether is caching enabled.
        /// </summary>
        public static bool IsCachingEnabled
        {
            get
            {
                bool isEnabled;

                bool.TryParse(ConfigurationManager.AppSettings["IsCachingEnabled"], out isEnabled);

                return isEnabled;
            }
        }

        #endregion
    }
}
