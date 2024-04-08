using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RentAndDelivery.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is FluentValidation.ValidationException validationException)
            {
                var errors = validationException.Errors
                    .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                    .ToList();

                var result = new ObjectResult(new { Errors = errors })
                {
                    StatusCode = 400, // Bad Request
                };

                context.Result = result;
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ArgumentNullException ||
                    context.Exception is KeyNotFoundException)
            {
                // Tratar erro 404 (Não Encontrado)
                context.Result = new NotFoundObjectResult(new { Error = "Resource not found!"});
                context.ExceptionHandled = true;
            }
            else if (context.Exception is InvalidOperationException)
            {
                // Tratar erro 400 Bad Request 
                context.Result = new BadRequestObjectResult(new { Error = context.Exception.Message});
                context.ExceptionHandled = true;
            }
            else if (context.Exception is HttpRequestException)
            {
                // Tratar erro 500 (Erro Interno do Servidor)
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                context.ExceptionHandled = true;
            }
        }
    }

}