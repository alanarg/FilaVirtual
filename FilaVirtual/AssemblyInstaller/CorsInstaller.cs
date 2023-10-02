using FilaVirtual.AssemblyInstaller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilaVirtual.AssemblyInstaller
{
    public class CorsInstaller : IInstaller
    {
        public void Run(IConfiguration configuration, IServiceCollection services)
        {
            services.AddCors();
        }
    }
}
