using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Watcher watcher = new Watcher();
            watcher.Start();
            await context.Response.WriteAsync("<br>Start third watcher!");
            await _next.Invoke(context);
            watcher.End();
            await context.Response.WriteAsync($"<br>Third watcher: {watcher.Milliseconds} ms");
        }
    }
}
