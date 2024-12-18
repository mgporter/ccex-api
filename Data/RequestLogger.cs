using Microsoft.AspNetCore.Http.Extensions;

namespace ccex_api.Data;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"{context.Request.Method}: {context.Request.GetDisplayUrl()}");
        await _next(context);
    }
}