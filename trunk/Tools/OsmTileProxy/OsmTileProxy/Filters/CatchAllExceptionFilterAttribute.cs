// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatchAllExceptionFilterAttribute.cs" company="Acme">
//   Copyright (c) Acme. All right reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OsmTileProxy.Filters
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Web.Http.Filters;

    using log4net;

    /// <summary>
    /// The exception filter attribute.
    /// </summary>
    public class CatchAllExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Static Fields

        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Catch all exceptions, and return an empty instead of returning the exception information.
        /// </summary>
        /// <param name="context">
        /// The request context.
        /// </param>
        public override void OnException(HttpActionExecutedContext context)
        {
            Log.FatalFormat("{0} --> Exception:[{1}].", MethodBase.GetCurrentMethod().Name, context.Exception.Message + "==>" + context.Exception.StackTrace);

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            MemoryStream memoryStream = Helper.GetBlankTile();

            httpResponseMessage.Content = new ByteArrayContent(memoryStream.ToArray());

            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            memoryStream.Dispose();

            context.Response = httpResponseMessage;
        }

        #endregion
    }
}
