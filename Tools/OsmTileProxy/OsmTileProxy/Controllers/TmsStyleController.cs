// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TmsStyleController.cs" company="Acme">
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
    /// The TMS style controller.
    /// </summary>
    public class TmsStyleController : ApiController
    {
        #region Constants

        /// <summary>
        /// The directory name where OpenStreetMap maps will be saved.
        /// </summary>
        private const string CacheDirectoryNameMsp = @"Msp";

        /// <summary>
        /// The URL template to use when downloading an Msp map.
        /// </summary>
        private const string UrlTemplateMsp = "https://geoegl.msp.gouv.qc.ca/cgi-wms/mapcache.fcgi/tms/1.0.0/carte_gouv_qc_public@EPSG_3857/{level}/{column}/{row}.png";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get an MSP tile that matches with an OpenStreetMap coordinate.
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
        [Route("api/msp/{level}/{column}/{row}.png")] // /api/msp/14/4951/5774.png
        public HttpResponseMessage GetMspTileWithSyntaxOsm(string level, string column, string row)
        {
            int tileLevel = Convert.ToInt32(level);

            int tileColumn = Convert.ToInt32(column);

            int tileRow = Convert.ToInt32(row);

            HttpResponseMessage httpResponseMessage;

            using (
                MemoryStream memoryStream =
                    this.GetTmsStyleTileWithOsmSyntax(
                        new GetTmsStyleTileWithOsmSyntaxArgument
                            {
                                UrlTemplate = UrlTemplateMsp, 
                                CacheDirectoryName = string.Format(@"{0}\{1}", CustomSettings.CacheRootDirectory, CacheDirectoryNameMsp), 
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
        /// Get an TMS style URL.
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
        private string GenerateTmsStyleUrl(string templateUrl, int tileLevel, int tileColumn, int tileRow)
        {
            string remoteImageUrl = templateUrl.Replace("{level}", tileLevel.ToString(CultureInfo.InvariantCulture));

            remoteImageUrl = remoteImageUrl.Replace("{column}", tileColumn.ToString(CultureInfo.InvariantCulture));

            return remoteImageUrl.Replace("{row}", tileRow.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Get an TMS style tile that matches with an OpenStreetMap coordinate.
        /// </summary>
        /// <param name="argument">
        /// DTO containing all values necessary to process the request.
        /// </param>
        /// <returns>
        /// A memory stream containing the image.
        /// </returns>
        private MemoryStream GetTmsStyleTileWithOsmSyntax(GetTmsStyleTileWithOsmSyntaxArgument argument)
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

            string staticMapsUrl = this.GenerateTmsStyleUrl(argument.UrlTemplate, argument.TileLevel, argument.TileColumn, reversedRowTilePosition);

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
