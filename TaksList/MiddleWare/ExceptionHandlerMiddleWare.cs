using TaksList.Exceptions;

namespace TaksList.MiddleWare
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
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
                _logger.LogWarning(ex, "Validação falhou");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new 
                {
                    status = context.Response.StatusCode,

                    message = ex.Message,

                    errors = ex.Errors.Select(e => new
                    {
                        property = e.PropertyName,

                        message = e.ErrorMessage
                    })
                 });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Recurso não encontrado");
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }
            catch (BusinessException ex)
            {
                _logger.LogWarning(ex, "Erro de negócio");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new
                {
                    status = context.Response.StatusCode,

                    message = ex.Message

                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new {
                    status = context.Response.StatusCode,

                    message = "Erro interno do servidor"

                } );
            }
        }
    }
}
