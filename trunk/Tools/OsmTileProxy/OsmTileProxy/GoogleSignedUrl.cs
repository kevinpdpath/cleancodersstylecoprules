// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleSignedUrl.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Class to manage digital dignatures for Google Urls.
    /// </summary>
    public static class GoogleSignedUrl
    {
        #region Public Methods and Operators

        /// <summary>
        /// Add a digital signature to a google Url.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="keyString">
        /// The key string.
        /// </param>
        /// <returns>
        /// The signed Url.
        /// </returns>
        public static string Sign(string url, string keyString)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            // converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
            string usablePrivateKey = keyString.Replace("-", "+").Replace("_", "/");
            byte[] privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

            Uri uri = new Uri(url);
            byte[] encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);

            // compute the hash
            HMACSHA1 algorithm = new HMACSHA1(privateKeyBytes);
            byte[] hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

            // convert the bytes to string and make url-safe by replacing '+' and '/' characters
            string signature = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");

            // Add the signature to the existing URI.
            return uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature;
        }

        #endregion
    }
}
