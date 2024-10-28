using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
           .ReadFrom.Configuration(builder.Configuration)
           .Enrich.FromLogContext()
           .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
           .CreateLogger();

builder.Logging.AddSerilog(logger);
builder.Services.InstallServiceAssembly(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandling>();

app.MapControllers();

app.UseStatusCodePages(async context =>
{
    if (
            context.HttpContext.Response.StatusCode == StatusCodes.Status401Unauthorized ||
            context.HttpContext.Response.StatusCode == StatusCodes.Status403Forbidden
        )
    {
        context.HttpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new OutputDTO<dynamic>()
        {
            Succeeded = false,
            HttpStatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized),
            Message = Convert.ToString(HttpStatusCode.Unauthorized),
            Data = null
        }));
    }


});

app.Run();
