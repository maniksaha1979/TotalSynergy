using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace TotalSynergy.WebAPI.App_Start
{
    public class LoggingExceptionMessageHandler : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            ILog logger = LogManager.GetLogger(typeof(ApiController));

            logger.Error(String.Format("Unhandled exception thrown in {0} for request {1}: {2}",
                                        context.Request.Method, context.Request.RequestUri, context.Exception.Message), context.Exception);
        }
    }
    
    
}