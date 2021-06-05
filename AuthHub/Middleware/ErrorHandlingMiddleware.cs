using CommonCore.Api.Extensions;
using CommonCore.Models.Exceptions;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AuthHub.Middleware
{

    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlingMiddleware(
            RequestDelegate next
            )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                ApiResponse<string> apiResponse = new ApiResponse<string>();

                switch (exception)
                {
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response.StatusCode = 400;
                        apiResponse = e.AsApiResponse();
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        apiResponse = exception.AsApiResponse();
                        break;
                }

                var result = JsonConvert.SerializeObject(apiResponse);
                await response.WriteAsync(result);
            }
        }
    }
}
