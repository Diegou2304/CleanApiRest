using CleanApiRest.Application.Cars.Exceptions;
using System.Net;
using System.Text.Json;

namespace CleanApiRest.Api
{
    public class ApplicationMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ApplicationMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                var statusCode = (int) HttpStatusCode.InternalServerError;
                var response = string.Empty;
                
                switch (ex)
                {
                    case CarNotFoundException notFoundException:
                        statusCode = (int) HttpStatusCode.NotFound;
                        response = "The requested Item could not be found";
                        break;
                }

                var errorResponse = new ErrorResponse(statusCode,response);

                var json = JsonSerializer.Serialize(errorResponse);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }


        }

       
    }
}
