using Microsoft.EntityFrameworkCore;
using MSSUPERA.Business.Models;

namespace FilaVirtual.AssemblyInstaller
{
    public class DbContextInstaller : IInstaller
    {
        public void Run(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<FilaVirtual_Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<FilaVirtual_Context>();
        }
    }
}
