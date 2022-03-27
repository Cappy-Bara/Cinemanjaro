using Cinemanjaro.Common.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Cinemanjaro.Bootstrapper.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CinemanjaroException ex)
            {
                _logger.LogWarning($"HANDLED EXCEPTION THROWN: CODE - {ex.StatusCode} - {ex.Message}");
                await WriteExceptionAsync(context, ex.ToErrorDetails((HttpStatusCode)ex.StatusCode));
            }
            catch (Exception ex)
            {
                _logger.LogError($"!UNHANDLED EXCEPTION THROWN: CODE - 500 - {ex.Message}");
                await WriteExceptionAsync(context, ex.ToErrorDetails());
            }
        }

        private static async Task WriteExceptionAsync(HttpContext context, ErrorDetails details)
        {
            ResponseDetails model = new ResponseDetails();
            model.ExceptionMessage = details.ExceptionMessage;
            model.StatusCode = details.StatusCode;
            string error = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            context.Response.StatusCode = (int)details.StatusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(error);
        }
    }
}
