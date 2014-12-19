// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetBingMapsTileWithOsmSyntaxArgument.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy.Dto
{
    /// <summary>
    /// DTO used with the GetBingMapsTileWithOsmSyntax function of the Bing Maps controller.
    /// </summary>
    public class GetBingMapsTileWithOsmSyntaxArgument
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Bing Maps Key.
        /// </summary>
        public string BingMapsKey { get; set; }

        /// <summary>
        /// Gets or sets the cache directory name.
        /// </summary>
        public string CacheDirectoryName { get; set; }

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
