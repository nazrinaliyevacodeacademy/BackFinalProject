using Final.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Final.API.Middlewares
    {
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionMiddleware> _logger;

            public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context); 
                }
            catch (NotFoundException nfEx)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = nfEx.Message
                });
            }
            catch (BusinessException bex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = bex.Message
                });
            }
            catch (UnauthorizedAccessAppException uaEx)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = uaEx.Message
                });
            }

            catch (ValidationException validationEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var errors = validationEx.Errors.Select(x => new
                    {
                        Property = x.PropertyName,
                        Error = x.ErrorMessage
                    });

                    var json = JsonSerializer.Serialize(new
                    {
                        Message = "Validation error",
                        Errors = errors
                    });

                    await context.Response.WriteAsync(json);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Unhandled exception: {ex.Message}");

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Server error occurred",
                        Detail = ex.Message
                    };

                    var json = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(json);
                }
            }
        }

}
