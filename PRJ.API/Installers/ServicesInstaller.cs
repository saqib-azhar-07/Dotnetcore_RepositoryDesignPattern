using PRJ.Service.Services.System.Login;
using PRJ.Service.Services.System.Registeration;

namespace PRJ.API.Installers;
public class ServicesInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ExceptionHandling>();
        services.AddSingleton<DapperContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUserService, UserService>();

    }
}
