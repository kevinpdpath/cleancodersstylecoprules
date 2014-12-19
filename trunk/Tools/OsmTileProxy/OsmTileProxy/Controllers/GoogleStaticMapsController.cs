// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleStaticMapsController.cs" company="Acme">
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
    /// The Google Static Maps controller.
    /// </summary>
    public class GoogleStaticMapsController : ApiController
    {
        #region Constants

        /// <summary>
        /// The directory name where hybrid maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameHybrid = @"GoogleMapsHybrid";

        /// <summary>
        /// The directory name where roadmaps will be saved.
        /// </summary>
        private const string CacheDirectoryNameRoadmap = @"GoogleMapsRoadmap";

        /// <summary>
        /// The directory name where satellite maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameSatellite = @"GoogleMapsSatellite";

        /// <summary>
        /// The directory name where terrain maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameTerrain = @"GoogleMapsTerrain";

        /// <summary>
        /// The URL template to use when downloading a hybrid map.
        /// </summary>
        private const string UrlTemplateHybrid = "http://maps.googleapis.com/maps/api/staticmap?center={lat},{long}&zoom={zoom}&size=400x400&maptype=hybrid";

        /// <summary>
        /// The URL template to use when downloading a regular roadmap.
        /// </summary>
        private const string UrlTemplateRoadmap = "http://maps.googleapis.com/maps/api/staticmap?center={lat},{long}&zoom={zoom}&size=400x400&maptype=roadmap";

        /// <summary>
        /// The URL template to use when downloading a satellite map.
        /// </summary>
        private const string UrlTemplateSatellite = "http://maps.googleapis.com/maps/api/staticmap?center={lat},{long}&zoom={zoom}&size=400x400&maptype=satellite";

        /// <summary>
        /// The URL template to use when downloading a terrain map.
        /// </summary>
        private const string UrlTemplateTerrain = "http://maps.googleapis.com/maps/api/staticmap?center={lat},{long}&zoom={zoom}&size=400x400&maptype=terrain";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get a Hybrid Static Maps tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/gmh/{level}/{column}/{row}.png")] // /api/gmh/14/4951/5774.png
        public HttpResponseMessage GetHybridTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetStaticMapsTileWithOsmSyntax(
                        new GetStaticMapsTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateHybrid, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameHybrid), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
                                GoogleMapsDeveloperKey = CustomSettings.GoogleMapsDeveloperKey,
                                GoogleForWorkClientId = CustomSettings.GoogleForWorkClientId,
                                GoogleForWorkPrivateKey = CustomSettings.GoogleForWorkPrivateKey,
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
        /// Get a Roadmap Static Maps tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/gmr/{level}/{column}/{row}.png")] // /api/gmr/14/4951/5774.png
        public HttpResponseMessage GetRoadmapTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetStaticMapsTileWithOsmSyntax(
                        new GetStaticMapsTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateRoadmap, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameRoadmap), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow,
                                GoogleMapsDeveloperKey = CustomSettings.GoogleMapsDeveloperKey,
                                GoogleForWorkClientId = CustomSettings.GoogleForWorkClientId,
                                GoogleForWorkPrivateKey = CustomSettings.GoogleForWorkPrivateKey,
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
        /// Get a Satellite Static Maps tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/gms/{level}/{column}/{row}.png")] // /api/gms/14/4951/5774.png
        public HttpResponseMessage GetSatelliteTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetStaticMapsTileWithOsmSyntax(
                        new GetStaticMapsTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateSatellite, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameSatellite), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow,
                                GoogleMapsDeveloperKey = CustomSettings.GoogleMapsDeveloperKey,
                                GoogleForWorkClientId = CustomSettings.GoogleForWorkClientId,
                                GoogleForWorkPrivateKey = CustomSettings.GoogleForWorkPrivateKey,
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
        /// Get a Terrain Static Maps tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/gmt/{level}/{column}/{row}.png")] // /api/gmt/14/4951/5774.png
        public HttpResponseMessage GetTerrainTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetStaticMapsTileWithOsmSyntax(
                        new GetStaticMapsTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateTerrain, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameTerrain), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow,
                                GoogleMapsDeveloperKey = CustomSettings.GoogleMapsDeveloperKey,
                                GoogleForWorkClientId = CustomSettings.GoogleForWorkClientId,
                                GoogleForWorkPrivateKey = CustomSettings.GoogleForWorkPrivateKey,
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
        /// Get a Static Maps For Work (Google Maps Static) URL.
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
        /// <param name="clientId">
        /// The Google For Work Client Id.
        /// </param>
        /// <param name="privateKey">
        /// The Google For Work Private Key
        /// </param>
        /// <returns>
        /// The Static Map (Google Maps Static) URL.
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "Overkill.")]
        private string GenerateStaticMapsForWorkUrl(string templateUrl, int tuileNiveau, double latitude, double longitude, string clientId, string privateKey)
        {
            string remoteImageUrl = templateUrl.Replace("{zoom}", tuileNiveau.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{lat}", latitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));

            remoteImageUrl = remoteImageUrl.Replace("{long}", longitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));

            remoteImageUrl = remoteImageUrl.Replace("{long}", longitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));

            remoteImageUrl = string.Format("{0}&client={1}", remoteImageUrl, clientId);

            return GoogleSignedUrl.Sign(remoteImageUrl, privateKey);
        }

        /// <summary>
        /// Get a Static Maps Developer (Google Maps Static) URL.
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
        private string GenerateStaticMapsDeveloperUrl(string templateUrl, int tuileNiveau, double latitude, double longitude, string key)
        {
            string remoteImageUrl = templateUrl.Replace("{zoom}", tuileNiveau.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{lat}", latitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));

            remoteImageUrl = remoteImageUrl.Replace("{long}", longitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));

            return string.Format("{0}&key={1}", remoteImageUrl, key);
        }

        /// <summary>
        /// Get a Google Maps tile that matches with an OpenStreetMap coordinate.
        /// </summary>
        /// <param name="argument">
        /// DTO containing all values necessary to process the request.
        /// </param>
        /// <returns>
        /// A memory stream containing the image.
        /// </returns>
        private MemoryStream GetStaticMapsTileWithOsmSyntax(GetStaticMapsTileWithOsmSyntaxArgument argument)
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

            string staticMapsUrl;

            if (string.IsNullOrEmpty(argument.GoogleMapsDeveloperKey) == false)
            {
                staticMapsUrl = this.GenerateStaticMapsDeveloperUrl(argument.UrlTemplate, argument.TileLevel, tileCenterCoordinate.Y, tileCenterCoordinate.X, argument.GoogleMapsDeveloperKey);
            }
            else if (string.IsNullOrEmpty(argument.GoogleForWorkClientId) == false && string.IsNullOrEmpty(argument.GoogleForWorkPrivateKey) == false)
            {
                staticMapsUrl = this.GenerateStaticMapsForWorkUrl(argument.UrlTemplate, argument.TileLevel, tileCenterCoordinate.Y, tileCenterCoordinate.X, argument.GoogleForWorkClientId, argument.GoogleForWorkPrivateKey);
            }
            else
            {
                throw new ArgumentException("Missing [GoogleMapsDeveloperKey] or [GoogleForWorkClientId and GoogleForWorkPrivateKey] values in the web.config file.");
            }

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
