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
    /// The OSM style controller.
    /// </summary>
    public class OsmStyleController : ApiController
    {
        #region Constants

        /// <summary>
        /// The directory name where MapQuest maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameMapQuest = @"MapQuest";

        /// <summary>
        /// The directory name where Stamen Toner Lite maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameOpenCycleMap = @"OpenCycleMap";

        /// <summary>
        /// The directory name where OpenStreetMap maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameOpenStreetMap = @"OpenStreetMap";

        /// <summary>
        /// The directory name where Stamen Toner maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameStamenToner = @"StamenToner";

        /// <summary>
        /// The directory name where Stamen Toner Lite maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameStamenTonerLite = @"StamenTonerLite";

        /// <summary>
        /// The URL template to use when downloading a MapQuest map.
        /// </summary>
        private const string UrlTemplateMapQuest = "http://otile3.mqcdn.com/tiles/1.0.0/osm/{level}/{column}/{row}.png";

        /// <summary>
        /// The URL template to use when downloading a Stamen Toner map.
        /// </summary>
        private const string UrlTemplateOpenCycleMap = "http://b.tile2.opencyclemap.org/transport/{level}/{column}/{row}.png";

        /// <summary>
        /// The URL template to use when downloading an OpenStreetMap map.
        /// </summary>
        private const string UrlTemplateOpenStreetMap = "http://a.tile.openstreetmap.org/{level}/{column}/{row}.png";

        /// <summary>
        /// The URL template to use when downloading a Stamen Toner map.
        /// </summary>
        private const string UrlTemplateStamenToner = "http://a.tile.stamen.com/toner/{level}/{column}/{row}.png";

        /// <summary>
        /// The URL template to use when downloading a Stamen Toner map.
        /// </summary>
        private const string UrlTemplateStamenTonerLite = "http://b.tile.stamen.com/toner-lite/{level}/{column}/{row}.png";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get a MapQuest tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/mq/{level}/{column}/{row}.png")] // /api/mq/14/4951/5774.png
        public HttpResponseMessage GetMapQuestTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetOsmStyleTileWithOsmSyntax(
                        new GetOsmStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateMapQuest, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameMapQuest), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
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
        /// Get a OpenCycleMap tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/ocm/{level}/{column}/{row}.png")] // /api/ocm/14/4951/5774.png
        public HttpResponseMessage GetOpenCycleMapTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetOsmStyleTileWithOsmSyntax(
                        new GetOsmStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateOpenCycleMap, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameOpenCycleMap), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
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
        /// Get a MapQuest tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/osm/{level}/{column}/{row}.png")] // /api/osm/14/4951/5774.png
        public HttpResponseMessage GetOsmTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetOsmStyleTileWithOsmSyntax(
                        new GetOsmStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateOpenStreetMap, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameOpenStreetMap), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
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
        /// Get a Stamen Toner Lite tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/stl/{level}/{column}/{row}.png")] // /api/stl/14/4951/5774.png
        public HttpResponseMessage GetStamenTonerLiteTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetOsmStyleTileWithOsmSyntax(
                        new GetOsmStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateStamenTonerLite, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameStamenTonerLite), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
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
        /// Get a Stamen Toner tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/st/{level}/{column}/{row}.png")] // /api/st/14/4951/5774.png
        public HttpResponseMessage GetStamenTonerTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetOsmStyleTileWithOsmSyntax(
                        new GetOsmStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateStamenToner, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameStamenToner), 
                                TileLevel = tileLevel, 
                                TileColumn = tileColumn, 
                                TileRow = tileRow, 
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
        /// <returns>
        /// The Static Map (Google Maps Static) URL.
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "Overkill.")]
        private string GenerateOsmStyleUrl(string templateUrl, int tileLevel, int tileColumn, int tileRow)
        {
            string remoteImageUrl = templateUrl.Replace("{level}", tileLevel.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{column}", tileColumn.ToString(CultureInfo.InvariantCulture));

            return remoteImageUrl.Replace("{row}", tileRow.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Get an OSM style tile that matches with an OpenStreetMap coordinate.
        /// </summary>
        /// <param name="argument">
        /// DTO containing all values necessary to process the request.
        /// </param>
        /// <returns>
        /// A memory stream containing the image.
        /// </returns>
        private MemoryStream GetOsmStyleTileWithOsmSyntax(GetOsmStyleTileWithOsmSyntaxArgument argument)
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

            string staticMapsUrl = this.GenerateOsmStyleUrl(argument.UrlTemplate, argument.TileLevel, argument.TileColumn, argument.TileRow);

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
