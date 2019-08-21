using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TotalSynergy.WebAPI
{
    public class LoggingMessageHandler:DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.LocalPath.StartsWith("/api/", StringComparison.OrdinalIgnoreCase))
            {
                var controllerType = typeof(ApiController);

                var requestInfo = string.Format("{0} {1}", request.Method, request.RequestUri);
                var correlationId = request.GetCorrelationId().ToString();

                var requestMessage = await request.Content.ReadAsStringAsync();

                await LogIncommingMessageAsync(controllerType, correlationId, requestInfo, requestMessage.Replace("\r\n", ""));

                var response = await base.SendAsync(request, cancellationToken);

                string responseMessage;

                if (response.IsSuccessStatusCode && response.Content != null)
                    responseMessage = await response.Content.ReadAsStringAsync();
                else
                    responseMessage = response.ReasonPhrase;

                await OutgoingMessageAsync(controllerType, correlationId, requestInfo, responseMessage, response.IsSuccessStatusCode);

                return response;
            }
            else
                return await base.SendAsync(request, cancellationToken);
        }

        protected async Task LogIncommingMessageAsync(Type type, string correlationId, string requestInfo, string body)
        {
            var logger = LogManager.GetLogger(type);
            await Task.Run(() => logger.Debug(String.Format("Service API Request - {0} {1}: \r\n{2}", correlationId, requestInfo, body)));
        }

        protected async Task OutgoingMessageAsync(Type type, string correlationId, string requestInfo, string body, bool isSuccess)
        {
            var logger = LogManager.GetLogger(type);
            if (isSuccess)
                await Task.Run(() => logger.Debug(String.Format("Service API Response - {0} {1}: \r\n{2}", correlationId, requestInfo, body)));
            else
                await Task.Run(() => logger.Warn(String.Format("Service API Response - {0} {1}: \r\n{2}", correlationId, requestInfo, body)));
        }
    }
}