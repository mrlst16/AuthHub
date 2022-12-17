using AuthHub.Models.Exceptions;
using Common.Extensions;
using Common.Models.Exceptions;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace AuthHub.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        public ErrorHandlingMiddleware()
        {
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
                    case AuthenticationException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        //Note that this is really "Unauthenticated" and that HTTP has this all wonky
                        //Likely for historical reasons
                        apiResponse = e.AsApiResponse();
                        break;
                    case UnauthorizedException e:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
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