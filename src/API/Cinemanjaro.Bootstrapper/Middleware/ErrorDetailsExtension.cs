using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Bootstrapper.Middleware
{
    public static class ErrorDetailsExtension
    {
        internal static ErrorDetails ToErrorDetails(this Exception ex, HttpStatusCode code = HttpStatusCode.InternalServerError)
        {
            return new ErrorDetails()
            {
                StatusCode = code,
                ExceptionMessage = ex.Message
            };
        }
    }
}
