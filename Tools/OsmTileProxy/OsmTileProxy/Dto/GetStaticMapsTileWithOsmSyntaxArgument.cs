// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetStaticMapsTileWithOsmSyntaxArgument.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy.Dto
{
    /// <summary>
    /// DTO used with the GetStaticMapsTileWithOsmSyntax function of the Static Maps controller.
    /// </summary>
    public class GetStaticMapsTileWithOsmSyntaxArgument
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the cache directory name.
        /// </summary>
        public string CacheDirectoryName { get; set; }

        /// <summary>
        /// Gets or sets the Google For Work Client Id.
        /// </summary>
        public string GoogleForWorkClientId { get; set; }

        /// <summary>
        /// Gets or sets the Google For Work Private Key.
        /// </summary>
        public string GoogleForWorkPrivateKey { get; set; }

        /// <summary>
        /// Gets or sets the Google Maps Developer Key.
        /// </summary>
        public string GoogleMapsDeveloperKey { get; set; }

        /// <summary>
        /// Gets or sets the Proxy URL.
        /// </summary>
        public string ProxyUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tile is to be saved in cache.
        /// </summary>
        public bool SaveInCache { get; set; }

        /// <summary>
        /// Gets or sets the column number.
        /// </summary>
        public int TileColumn { get; set; }

        /// <summary>
        /// Gets or sets the tile level.
        /// </summary>
        public int TileLevel { get; set; }

        /// <summary>
        /// Gets or sets the row number.
        /// </summary>
        public int TileRow { get; set; }

        /// <summary>
        /// Gets or sets the Google Maps Url Template.
        /// </summary>
        public string UrlTemplate { get; set; }

        #endregion
    }
}
