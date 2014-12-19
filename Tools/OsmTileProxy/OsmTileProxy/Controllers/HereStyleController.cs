// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OsmStyleController.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;

    using OsmTileProxy.Dto;

    /// <summary>
    /// The Here style controller.
    /// </summary>
    public class HereStyleController : ApiController
    {
        #region Constants

        /// <summary>
        /// The directory name where Here Map Tile maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameHereMapTile = @"HereMapTile";

        /// <summary>
        /// The directory name where Here Map Image maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameHereMapImage = @"HereMapImage";

        /// <summary>
        /// The URL template to use when downloading a Here Map Tile map.
        /// </summary>
        private const string UrlTemplateHereMapTile = "http://1.base.maps.cit.api.here.com/maptile/2.1/maptile/newest/normal.day/{level}/{column}/{row}/256/png8?app_id={appId}&app_code={appCode}";

        /// <summary>
        /// The URL template to use when downloading a Here Map Image map.
        /// </summary>
        private const string UrlTemplateHereMapImage = "http://2.aerial.maps.cit.api.here.com/maptile/2.1/maptile/newest/satellite.day/{level}/{column}/{row}/256/png8?app_id={appId}&app_code={appCode}";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get a Here tile that matches with an OpenStreetMap coordinate.
        /// </summary>
        /// <param name="level">
        /// The tile level.
        /// </param>
        /// <param name="column">
        /// The tile column.
        /// </param>
        /// <param name="row">
        /// The tile row.
        /// </param>
        /// <returns>
        /// An http response message containing an image, even if failure occurred.
        /// </returns>
        [HttpGet]
        [Route("api/hmt/{level}/{column}/{row}.png")] // /api/hmt/14/4951/5774.png
        public HttpResponseMessage GetHereMapTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetHereStyleTileWithOsmSyntax(
                        new GetHereStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateHereMapTile,
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameHereMapTile), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
                                SaveInCache = CustomSettings.IsCachingEnabled,
                                HereAppCodeKey = CustomSettings.HereAppCode,
                                HereAppIdKey = CustomSettings.HereAppId
                            }))
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(memoryStream.ToArray()) };
            }

            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            Helper.SetResponseCaching(httpResponseMessage, DateTime.Now, 60 * 60 * 24 * 7, this.Request.RequestUri.ToString());

            return httpResponseMessage;
        }

        /// <summary>
        /// Get a Here Map Image tile that matches with an OpenStreetMap coordinate.
        /// </summary>
        /// <param name="level">
        /// The tile level.
        /// </param>
        /// <param name="column">
        /// The tile column.
        /// </param>
        /// <param name="row">
        /// The tile row.
        /// </param>
        /// <returns>
        /// An http response message containing an image, even if failure occurred.
        /// </returns>
        [HttpGet]
        [Route("api/hmi/{level}/{column}/{row}.png")] // /api/hmi/14/4951/5774.png
        public HttpResponseMessage GetHereImageTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetHereStyleTileWithOsmSyntax(
                        new GetHereStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateHereMapImage,
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameHereMapImage), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
                                SaveInCache = CustomSettings.IsCachingEnabled,
                                HereAppCodeKey = CustomSettings.HereAppCode,
                                HereAppIdKey = CustomSettings.HereAppId
                            }))
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(memoryStream.ToArray()) };
            }

            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            Helper.SetResponseCaching(httpResponseMessage, DateTime.Now, 60 * 60 * 24 * 7, this.Request.RequestUri.ToString());

            return httpResponseMessage;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get an OSM style URL.
        /// </summary>
        /// <param name="templateUrl">
        /// The OSM style URL Template.
        /// </param>
        /// <param name="tileLevel">
        /// The tile level.
        /// </param>
        /// <param name="tileColumn">
        /// The tile column.
        /// </param>
        /// <param name="tileRow">
        /// The tile row.
        /// </param>
        /// <param name="appCode">
        /// The app code.
        /// </param>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <returns>
        /// The Static Map (Google Maps Static) URL.
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "Overkill.")]
        private string GenerateHereStyleUrl(string templateUrl, int tileLevel, int tileColumn, int tileRow, string appCode, string appId)
        {
            string remoteImageUrl = templateUrl.Replace("{level}", tileLevel.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{column}", tileColumn.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{row}", tileRow.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{appCode}", appCode.ToString(CultureInfo.InvariantCulture));

            return remoteImageUrl.Replace("{appId}", appId.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Get an Here style tile that matches with an OpenStreetMap coordinate.
        /// </summary>
        /// <param name="argument">
        /// DTO containing all values necessary to process the request.
        /// </param>
        /// <returns>
        /// A memory stream containing the image.
        /// </returns>
        private MemoryStream GetHereStyleTileWithOsmSyntax(GetHereStyleTileWithOsmSyntaxArgument argument)
        {
            string fullPathTileInCache = Helper.FormatFullPathTileInCache(argument.CacheDirectoryName, argument.TileLevel, argument.TileColumn, argument.TileRow);

            if (File.Exists(fullPathTileInCache))
            {
                MemoryStream memoryStream = new MemoryStream();

                using (FileStream fileStream = File.OpenRead(fullPathTileInCache))
                {
                    fileStream.CopyTo(memoryStream);
                }

                return memoryStream;
            }

            string staticMapsUrl = this.GenerateHereStyleUrl(argument.UrlTemplate, argument.TileLevel, argument.TileColumn, argument.TileRow, argument.HereAppCodeKey, argument.HereAppIdKey);

            MemoryStream memoryStreamDownload = Helper.DownloadImage(staticMapsUrl);

            if (argument.SaveInCache)
            {
                Helper.SaveTileInCache(fullPathTileInCache, memoryStreamDownload);
            }

            return memoryStreamDownload;
        }

        #endregion
    }
}
