using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using ProductsAPI.Features.Shared.Models;
using log4net.Core;
using log4net;

namespace ProductsAPI.IoC
{
    /// <summary>
    /// Represents implementation of <see cref="ExceptionLogger"/>.
    /// </summary>
    public class ApiExceptionLogger : ExceptionLogger
    {
        private readonly ILog _logger;

        public ApiExceptionLogger(ILog logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Overrides <see cref="ExceptionLogger.LogAsync"/> method with custom logger implementations.
        /// </summary>
        /// <param name="context">Instance of <see cref="ExceptionLoggerContext"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        public override async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            _logger.Error(string.Format("api exception ({0})", context.ExceptionContext.Request.GetCorrelationId()), context.Exception);
            var request = await CreateRequest(context.Request);
        }

        private static async Task<HttpRequestModel> CreateRequest(HttpRequestMessage message)
        {
            var request = new HttpRequestModel
            {
                Body = await message.Content.ReadAsStringAsync(),
                Method = message.Method.Method,
                Scheme = message.RequestUri.Scheme,
                Host = message.RequestUri.Host,
                Protocol = string.Empty,
                PathBase = message.RequestUri.PathAndQuery,
                Path = message.RequestUri.AbsoluteUri,
                QueryString = message.RequestUri.Query
            };

            return request;
        }
    }
}