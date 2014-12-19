// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;

    /// <summary>
    /// The web api application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        #region Methods

        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
        }

        #endregion
    }
}
