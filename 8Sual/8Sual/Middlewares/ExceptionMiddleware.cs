using _8Sual.Wrappers;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace _8Sual.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var serviceResponse = new ServiceResponse<string>(null);

            if (exception.GetType() == typeof(ValidationException))
            {
                serviceResponse.StatusCode = (int)HttpStatusCode.BadRequest;


                var validationError = (List<FluentValidation.Results.ValidationFailure>)((ValidationException)exception).Errors;
                string[] errors = validationError.Select(x => x.ErrorMessage).ToArray();

                serviceResponse.Errors = errors;
            }
            else
            {
                serviceResponse.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorMessage = (exception.InnerException != null) ? exception.InnerException.Message : exception.Message;
                serviceResponse.Errors = new string[] {errorMessage};

            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var result = JsonSerializer.Serialize(serviceResponse, options);
            return context.Response.WriteAsync(result);


        }
    }
}
