using Microsoft.OpenApi.Models;
using static FilaVirtual.Configurations.SwaggerConfig;

namespace FilaVirtual.AssemblyUse
{
    public class SwaggerUse : IUse
    {
        public void Use(WebApplication app, IWebHostEnvironment env)
        {
            app.UseMiddleware<SwaggerAuthorizedMiddleware>();
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "filaVirtual/v1/swagger/{documentName}/swagger.json";
                //c.RouteTemplate = "k0794/escutamswebapi/v1/swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("filaVirtual/v1/swagger/v1/swagger.json", "`PPA - API");
                //c.SwaggerEndpoint("/k0794/escutamswebapi/v1/swagger/v1/swagger.json", "`PPA- API");                
                c.RoutePrefix = "filaVirtual/v1/swagger";
                //c.RoutePrefix = "k0794/escutamswebapi/v1/swagger";
            });
            
        }
    }

}

