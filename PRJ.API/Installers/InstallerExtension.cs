﻿
namespace PRJ.API.Installers;
public static class InstallerExtension
{
    public static void InstallServiceAssembly(this IServiceCollection services, IConfiguration configuration)
    {
        var installers = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x)
                         && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
                         .Cast<IInstaller>().ToList();

        installers.ForEach(installer => installer.InstallServices(services, configuration));
    }
}
