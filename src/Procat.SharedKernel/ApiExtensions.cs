using LanguageExt.Common;
using Microsoft.AspNetCore.Http;

namespace Procat.SharedKernel;

public static class ApiExtensions
{
    extension(Error error)
    {
        public Microsoft.AspNetCore.Mvc.ProblemDetails ToProblemDetails(HttpContext httpContext)
        {
            return new Microsoft.AspNetCore.Mvc.ProblemDetails
            {
                Title = error.Message,
                Status = error.Code,
                Instance = httpContext.Request.Path
            };
        }
    }
}