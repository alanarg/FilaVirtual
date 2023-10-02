using FilaVirtual.AssemblyInstaller;
using FilaVirtual.Business.Interfaces;
using FilaVirtual.Business.Interfaces.Service;
using FilaVirtual.Business.Notificacoes;
using FilaVirtual.Business.Services;


namespace FilaVirtual.AssemblyInstaller
{
    public class DependecyInjectionInstaller : IInstaller
    {
        public void Run(IConfiguration configuration, IServiceCollection services)
        {
            services.ResolveDependencies();
        }
    }

    static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
			services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ILogAtividadeService, LogAtividadeService>();
			return services;
        }
    }
}