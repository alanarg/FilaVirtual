using AutoMapper;
using FilaVirtual.AssemblyInstaller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FilaVirtual.AssemblyInstaller
{
    public class AutoMapperInstaller : IInstaller
    {

        public void Run(IConfiguration configuration, IServiceCollection services)
        {            
            //services.AddAutoMapper(typeof(Program));

        }
	}

     class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        }
    }
}
