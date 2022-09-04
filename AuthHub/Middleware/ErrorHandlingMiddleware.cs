using Common.Extensions;
using Common.Models.Exceptions;
using Common.Models.Responses;
using FluentValidation;
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

        public ErrorHandlingMiddleware()
        {
        }

        public ErrorHandlingMiddleware(
            RequestDelegate next
            ) : this()
        {
            _next = next;
        }

        public async Task Handle(HttpContext context, Func<Task> next)
        {
            try
            {
                await next();
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
                        apiResponse = e.AsApiResponse();
                        break;
                    case HttpException e:
                        response.StatusCode = e.StatusCode;
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
