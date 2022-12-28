using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ve)
        {
            await HandleValidationExceptionAsync(context, ve);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }
    
    private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        // Todo: Create custom problem details that has less error info
        await context.Response.WriteAsJsonAsync(new
        {
            Detail = "One or more errors occured",
            Status = context.Response.StatusCode,
            Title = "Bad Request",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Errors = exception.Errors
        });
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        // Todo: ex.message might be too much detail for client
        await context.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Detail = exception.Message,
            Status = context.Response.StatusCode,
            Title = "Internal Server Error",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        });
    }
}