// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Helper.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Hosting;

    using log4net;

    /// <summary>
    /// Helper class containing miscellaneous functions shared amongst the controllers.
    /// </summary>
    public static class Helper
    {
        #region Static Fields

        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Crop a 400x400 pixel to a 256x256 pixel image, while keeping the image centered.
        /// </summary>
        /// <param name="memoryStream">
        /// A memory stream of the image to be cropped.
        /// </param>
        /// <returns>
        /// A memory stream of the cropped image.
        /// </returns>
        public static MemoryStream CropTile(MemoryStream memoryStream)
        {
            Bitmap original = new Bitmap(memoryStream);

            Rectangle cropArea = new Rectangle(72, 72, 256 + 72, 256 + 72);

            Bitmap destination = new Bitmap(256, 256, PixelFormat.Format16bppRgb555);

            Graphics graphics = Graphics.FromImage(destination);

            graphics.SmoothingMode = SmoothingMode.HighQuality;

            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            graphics.DrawImage(original, 0, 0, cropArea, GraphicsUnit.Pixel);

            MemoryStream cropMemoryStream = new MemoryStream();

            destination.Save(cropMemoryStream, ImageFormat.Png);

            cropMemoryStream.Seek(0, SeekOrigin.Begin);

            return cropMemoryStream;
        }

        /// <summary>
        /// Download an image from a URL.
        /// </summary>
        /// <param name="imageUrl">
        /// The URL of the image.
        /// </param>
        /// <returns>
        /// A stream containing an image.
        /// </returns>
        public static MemoryStream DownloadImage(string imageUrl)
        {
            Log.InfoFormat("{0} where imageUrl:[  {1}  ].", MethodBase.GetCurrentMethod().Name, imageUrl);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(imageUrl);

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

            if ((response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Redirect)
                && response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {
                MemoryStream memoryStream = new MemoryStream();

                using (Stream stream = response.GetResponseStream())
                {
                    stream.CopyTo(memoryStream);
                }

                return memoryStream;
            }

            throw new Exception(string.Format("{0}:{1}\n{2}", response.StatusCode, response.StatusDescription, imageUrl));
        }

        /// <summary>
        /// Format the full path of a tile in the cache directory structure.
        /// </summary>
        /// <param name="cacheDirectoryName">
        /// The cache directory name of the tile file.
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
        /// The full path of the tile file in the cache directory structure.
        /// </returns>
        [SuppressMessage("CleanCodersStyleCopRules.CleanCoderAnalyzer", "CC0042:MethodHasTooManyArgument", Justification = "Overkill.")]
        public static string FormatFullPathTileInCache(string cacheDirectoryName, int tileLevel, int tileColumn, int tileRow)
        {
            return string.Format(@"{0}\{1}\{2}\{3}.png", cacheDirectoryName, tileLevel, tileColumn, tileRow);
        }

        /// <summary>
        /// Get a blank tile.
        /// </summary>
        /// <returns>
        /// A memory stream containing the empty/blank tile.
        /// </returns>
        public static MemoryStream GetBlankTile()
        {
            string blankTileFullPath = HostingEnvironment.MapPath("~/Content/blank.png");

            MemoryStream memoryStream = new MemoryStream();

            using (FileStream fileStream = File.OpenRead(blankTileFullPath))
            {
                fileStream.CopyTo(memoryStream);

                return memoryStream;
            }
        }

        /// <summary>
        /// Calculate the checksum (MD5) of a text string.
        /// </summary>
        /// <param name="message">
        /// The string for which the checksum will be calculated.
        /// </param>
        /// <returns>
        /// The checksum.
        /// </returns>
        public static string GetChecksumTextString(string message)
        {
            byte[] arrayBytes = new byte[message.Length * sizeof(char)];

            Buffer.BlockCopy(message.ToCharArray(), 0, arrayBytes, 0, arrayBytes.Length);

            using (MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider())
            {
                byte[] hashs = cryptoServiceProvider.ComputeHash(arrayBytes);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashs.Length; i++)
                {
                    stringBuilder.Append(i.ToString("x2"));
                }

                return stringBuilder.ToString().ToUpper();
            }
        }

        /// <summary>
        /// Calculate the maximum number of tile in the row (Y) axis at a particular level.
        /// </summary>
        /// <param name="tileLevel">
        /// The tile level.
        /// </param>
        /// <returns>
        /// The maximum number of tile in the row (Y) axis at a particular level.
        /// </returns>
        public static int GetMaximumNumberTilePerRow(int tileLevel)
        {
            return Convert.ToInt32(Math.Pow(2, tileLevel));
        }

        /// <summary>
        /// Calculate the inverse row position of a tile.
        /// </summary>
        /// <param name="tileLevel">
        /// The tile level.
        /// </param>
        /// <param name="tileRow">
        /// The tile row.
        /// </param>
        /// <returns>
        /// The inverse row position of a tile.
        /// </returns>
        public static int GetReversedRowTilePosition(int tileLevel, int tileRow)
        {
            int maximumNumberTilePerRow = GetMaximumNumberTilePerRow(tileLevel);

            return maximumNumberTilePerRow - tileRow - 1;
        }

        /// <summary>
        /// Save a tile in the cache directory structure.
        /// </summary>
        /// <param name="fullPathTileInCache">
        /// The full path of a tile in the cache directory structure.
        /// </param>
        /// <param name="memoryStream">
        /// A memory stream containing the tile to be saved.
        /// </param>
        public static void SaveTileInCache(string fullPathTileInCache, MemoryStream memoryStream)
        {
            string tileDirectory = Path.GetDirectoryName(fullPathTileInCache);

            Directory.CreateDirectory(tileDirectory);

            using (FileStream fileStream = new FileStream(fullPathTileInCache, FileMode.Create, FileAccess.Write))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);

                byte[] bytes = new byte[memoryStream.Length];

                memoryStream.Read(bytes, 0, (int)memoryStream.Length);

                fileStream.Write(bytes, 0, bytes.Length);

                memoryStream.Seek(0, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Set the caching attributes of the response.
        /// </summary>
        /// <param name="httpResponseMessage">
        /// The http response message.
        /// </param>
        /// <param name="requestMoment">
        /// Moment of the request.
        /// </param>
        /// <param name="maximumCacheSecond">
        /// The maximum Cache Second.
        /// </param>
        /// <param name="originalRequestUri">
        /// The original request Uri.
        /// </param>
        public static void SetResponseCaching(HttpResponseMessage httpResponseMessage, DateTime requestMoment, int maximumCacheSecond, string originalRequestUri)
        {
            httpResponseMessage.Headers.CacheControl = new CacheControlHeaderValue { Public = true, MaxAge = TimeSpan.FromSeconds(maximumCacheSecond) };

            httpResponseMessage.Content.Headers.LastModified = requestMoment;

            string checksum = GetChecksumTextString(originalRequestUri);

            httpResponseMessage.Headers.ETag = new EntityTagHeaderValue(string.Format("\"W/{0}\"", checksum));
        }

        #endregion
    }
}
