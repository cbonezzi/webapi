using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WA1.Attributes
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// use for handling error for server
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var request = context.ActionContext.Request;
            context.Response = request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Error 500");
        }
    }
}