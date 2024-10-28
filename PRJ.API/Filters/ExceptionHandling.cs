using Serilog;
using Serilog.Context;

namespace PRJ.API.Filters;

public class ExceptionHandling : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        LogContext.PushProperty("xyz", 3333);

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new OutputDTO<dynamic>()
            {
                Succeeded = false,
                HttpStatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                Message = ex.Message,
                Data = null
            });
            await context.Response.WriteAsync(result);
        }
    }
}
