using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FilaVirtual.AssemblyInstaller;
using FilaVirtual.Util.Configuration;
using FIlaVirtual.Util.Configuration;

namespace FilaVirtual.AssemblyInstaller
{
    public class AuthenticatonInstaller : IInstaller
	{
		public void Run(IConfiguration configuration, IServiceCollection services)
		{
			var signingConfigurations = new SigningConfiguration();

			services.AddSingleton(signingConfigurations);

			var tokenConfigurations = new TokenConfiguration();

			new ConfigureFromConfigurationOptions<TokenConfiguration>(
				configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);

			services.AddSingleton(tokenConfigurations);

			services.AddAuthentication(authOptions =>
			{
				authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(bearerOptions =>
			{
				bearerOptions.RequireHttpsMetadata = false;
				bearerOptions.SaveToken = true;

				bearerOptions.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = false,
					ValidIssuer = tokenConfigurations.Issuer,
					ValidAudience = tokenConfigurations.Audience,
					IssuerSigningKey = signingConfigurations.Key,
					ValidateIssuer = false,
					ValidateAudience = false,
					RequireExpirationTime = tokenConfigurations.IsExpiration,
					ClockSkew = TimeSpan.Zero
				};

				bearerOptions.Events = new JwtBearerEvents
				{
					OnMessageReceived = context =>
					{
						var header = context.HttpContext.Request.Headers["Custom-Authorization"].ToString();
						if (!string.IsNullOrEmpty(header))
						{
							context.Token = header;
						}
						return Task.CompletedTask;
					}
				};

			});		
		}
	}
}
