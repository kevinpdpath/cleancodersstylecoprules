// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy
{
    using System.Web.Http;

    using OsmTileProxy.Filters;

    /// <summary>
    /// The web api config.
    /// </summary>
    public static class WebApiConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            GlobalConfiguration.Configuration.Filters.Add(new CatchAllExceptionFilterAttribute());
        }

        #endregion
    }
}
