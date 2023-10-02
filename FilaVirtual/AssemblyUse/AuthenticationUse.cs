using FilaVirtual.AssemblyUse;

namespace FilaVirtual.AssemblyUse
{
    public class AuthenticationUse : IUse
    {
        public void Use(WebApplication app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

			app.UseRouting();

			app.UseAuthorization();

			//app.MapControllers();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSession();
        }
    }
}
