using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;
using System.Text.Json;

namespace PRJ.API.Installers;
public class DataInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MainContext>(opt => opt.UseSqlServer(ConfigurationStrings.DBConntectionString));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        services.AddControllers();
        services.AddCors();
        services.AddControllers(options =>
        {
            //options.Filters.Add(typeof(ExceptionFilter));
            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        })
           .AddJsonOptions(
               options =>
               {
                   options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                   options.JsonSerializerOptions.PropertyNamingPolicy = null;
                   options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                   options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
               });
    }
}
