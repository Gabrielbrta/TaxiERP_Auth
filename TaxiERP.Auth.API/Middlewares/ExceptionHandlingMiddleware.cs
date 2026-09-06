using FluentValidation;
using System.Net;
using System.Text.Json;

namespace TaxiERP.Auth.API.Middlewares
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

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning("Erro de validação: {Errors}", ex.Errors);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var erros = ex.Errors.Select(e => new
                {
                    campo = e.PropertyName,
                    mensagem = e.ErrorMessage
                });

                var resposta = new { erros };

                await context.Response.WriteAsJsonAsync(resposta);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Ocorreu um erro inesperado");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var resposta = new { erro = "Ocorreu um erro inesperado no servidor. Tente novamente mais tarde." };
                await context.Response.WriteAsJsonAsync(resposta);
            }
        }
    }
}
