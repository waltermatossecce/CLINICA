using CLINICA.Application.UseCase.Commons.Base;
using CLINICA.Application.UseCase.Commons.Exceptions;
using CLINICA.Utilities.Constantes;
using System.Text.Json;

namespace CLINICA.Api.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationExceptions ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = GlobalMessage.MESSAGE_VALIDATE,
                    Errors = ex.Errors
                }); ;
            }
        }
    }
}
