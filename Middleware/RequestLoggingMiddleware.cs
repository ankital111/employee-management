using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using System;

namespace employee_management.Middleware
{
    // 🔹 Middleware runs for every HTTP request
    // Used here to log requests (cross-cutting concern)
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var log = $"[{DateTime.Now}] {context.Request.Method} {context.Request.Path}\n";
            await File.AppendAllTextAsync("Logs/app_log.txt", log);
            await _next(context); // pass control to next middleware
        }
    }
}
