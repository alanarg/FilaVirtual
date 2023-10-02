using FilaVirtual.AssemblyUse;

namespace FilaVirtual.AssemblyUse
{
    public class API_7_ConfigurationUse : IUse
    {
        public void Use(WebApplication app, IWebHostEnvironment env)
        {
            //app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
			
			app.UseCors(x => x
			   .AllowAnyMethod()
			   .AllowAnyHeader()
			   .SetIsOriginAllowed(origin => true) // allow any origin
			   .AllowCredentials());

		}
	}
}
