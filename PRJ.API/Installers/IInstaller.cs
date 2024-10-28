
namespace PRJ.API.Installers;
interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
