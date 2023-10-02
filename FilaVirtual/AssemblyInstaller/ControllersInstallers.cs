using FilaVirtual.Util.DateTimeConverter;


namespace FilaVirtual.AssemblyInstaller
{
    public class ControllersInstallers : IInstaller
    {
        public void Run(IConfiguration configuration, IServiceCollection services)
        {
            services.AddControllers()
              .AddNewtonsoftJson(options =>
              {
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				  options.SerializerSettings.Converters.Add(new DateTimeConverter());
			  });

            //services.AddEndpointsApiExplorer();
        }
    }

}
