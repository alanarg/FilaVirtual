using FilaVirtual.AssemblyInstaller;
using Microsoft.OpenApi.Models;
using static FilaVirtual.Configurations.SwaggerConfig;

namespace FilaVirtual.AssemblyInstaller
{
    public class SwaggerInstaller : IInstaller
    {
        public void Run(IConfiguration configuration, IServiceCollection services)
        {
			services.AddSwaggerGen(c =>
			{
				c.OperationFilter<SwaggerDefaultValues>();
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "PPAWEBAPI",
					Version = "v1",
					Contact = new OpenApiContact
					{
						Name = "SGI",
						Url = new Uri("http://www.sgi.ms.gov.br")
					}
				});

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "Autorization JWT no Header usando esquema Bearer. Insira apenas o Token no campo abaixo.",
					Name = "Authorization",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,

					Type = SecuritySchemeType.Http,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					}, new string[] {}
				}
					
			});
				c.AddSecurityDefinition("Custom-Authorization", new OpenApiSecurityScheme
				{
					Description = "Autorização JWT no cabeçalho usando esquema Bearer. Exemplo: \"Bearer {token}\"",
					Name = "Custom-Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Custom-Authorization"
								},
								Name = "Custom-Authorization",
								In = ParameterLocation.Header,

							},
							new List<string>()
						}
					});
			});
		}
        
    }
}
