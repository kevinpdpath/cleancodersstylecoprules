// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BingMapsController.cs" company="Acme">
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
    /// The Bing Maps controller.
    /// </summary>
    public class BingMapsController : ApiController
    {
        #region Constants

        /// <summary>
        /// The directory name where aerial maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameAerial = @"BingMapsAerial";

        /// <summary>
        /// The directory name where aerial with labels maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameAerialWithLabels = @"BingMapsAerialWithLabels";

        /// <summary>
        /// The directory name where road maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameRoad = @"BingMapsRoad";

        /// <summary>
        /// The URL template to use when downloading an aerial map.
        /// </summary>
        private const string UrlTemplateAerial = "http://dev.virtualearth.net/REST/v1/Imagery/Map/Aerial/{lat},{long}/{zoom}?mapSize=400,400&key={key}";

        /// <summary>
        /// The URL template to use when downloading an aerial with labels map.
        /// </summary>
        private const string UrlTemplateAerialWithLabels = "http://dev.virtualearth.net/REST/v1/Imagery/Map/AerialWithLabels/{lat},{long}/{zoom}?mapSize=400,400&key={key}";

        /// <summary>
        /// The URL template to use when downloading a road map.
        /// </summary>
        private const string UrlTemplateRoad = "http://dev.virtualearth.net/REST/v1/Imagery/Map/Road/{lat},{long}/{zoom}?mapSize=400,400&key={key}";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get an Aerial tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/bma/{level}/{column}/{row}.png")] // /api/bma/14/4951/5774.png
        public HttpResponseMessage GetAerialTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetBingMapsTileWithOsmSyntax(
                        new GetBingMapsTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateAerial, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameAerial), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
                                BingMapsKey = CustomSettings.BingMapsKey, 
                                SaveInCache = CustomSettings.IsCachingEnabled
                            }))
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(memoryStream.ToArray()) };
            }

            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            Helper.SetResponseCaching(httpResponseMessage, DateTime.Now, 60 * 60 * 24 * 7, this.Request.RequestUri.ToString());

            return httpResponseMessage;
        }

        /// <summary>
        /// Get an Aerial With Labels tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/bmal/{level}/{column}/{row}.png")] // /api/bmal/14/4951/5774.png
        public HttpResponseMessage GetAerialWithLabelsTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetBingMapsTileWithOsmSyntax(
                        new GetBingMapsTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateAerialWithLabels, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameAerialWithLabels), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
                                BingMapsKey = CustomSettings.BingMapsKey, 
                                SaveInCache = CustomSettings.IsCachingEnabled
                            }))
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(memoryStream.ToArray()) };
            }

            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            Helper.SetResponseCaching(httpResponseMessage, DateTime.Now, 60 * 60 * 24 * 7, this.Request.RequestUri.ToString());

            return httpResponseMessage;
        }

        /// <summary>
        /// Get an Road tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/bmr/{level}/{column}/{row}.png")] // /api/bmr/14/4951/5774.png
        public HttpResponseMessage GetRoadTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetBingMapsTileWithOsmSyntax(
                        new GetBingMapsTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateRoad, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameRoad), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
                                BingMapsKey = CustomSettings.BingMapsKey, 
                                SaveInCache = CustomSettings.IsCachingEnabled
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
        /// Get a Static Maps (Google Maps Static) URL.
        /// </summary>
        /// <param name="templateUrl">
        /// The Static Maps URL Template.
        /// </param>
        /// <param name="tuileNiveau">
        /// The tile level.
        /// </param>
        /// <param name="latitude">
        /// The latitude coordinate.
        /// </param>
        /// <param name="longitude">
        /// The longitude coordinate.
        /// </param>
        /// <param name="key">
        /// The Google Maps key.
        /// </param>
        /// <returns>
        /// The Static Map (Google Maps Static) URL.
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "Overkill.")]
        private string GenerateBingMapsUrl(string templateUrl, int tuileNiveau, double latitude, double longitude, string key)
        {
            string remoteImageUrl = templateUrl.Replace("{zoom}", tuileNiveau.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{lat}", latitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));

            remoteImageUrl = remoteImageUrl.Replace("{long}", longitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));

            return remoteImageUrl.Replace("{key}", key);
        }

        /// <summary>
        /// Get a Bing Maps tile that matches with an OpenStreetMap coordinate.
        /// </summary>
        /// <param name="argument">
        /// DTO containing all values necessary to process the request.
        /// </param>
        /// <returns>
        /// A memory stream containing the image.
        /// </returns>
        private MemoryStream GetBingMapsTileWithOsmSyntax(GetBingMapsTileWithOsmSyntaxArgument argument)
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

            int reversedRowTilePosition = Helper.GetReversedRowTilePosition(argument.TileLevel, argument.TileRow);

            GlobalMercator globalMercator = new GlobalMercator();

            CoordinatePair tileCenterCoordinate = globalMercator.GetLatLongTileCenter(argument.TileColumn, reversedRowTilePosition, argument.TileLevel);

            string staticMapsUrl = this.GenerateBingMapsUrl(argument.UrlTemplate, argument.TileLevel, tileCenterCoordinate.Y, tileCenterCoordinate.X, argument.BingMapsKey);

            MemoryStream cropTileMemoryStream;

            using (MemoryStream memoryStream = Helper.DownloadImage(staticMapsUrl))
            {
                cropTileMemoryStream = Helper.CropTile(memoryStream);
            }

            if (argument.SaveInCache)
            {
                Helper.SaveTileInCache(fullPathTileInCache, cropTileMemoryStream);
            }

            return cropTileMemoryStream;
        }

        #endregion
    }
}
