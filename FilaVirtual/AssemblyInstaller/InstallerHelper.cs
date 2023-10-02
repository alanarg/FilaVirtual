using FilaVirtual.AssemblyInstaller;
using System.Reflection;

namespace FilaVirtual.AssemblyInstaller
{
    public static class InstallerHelper
	{
		public static void InstallServices(this IServiceCollection service, IConfiguration configure)
		{
			var installers = Assembly.GetExecutingAssembly().GetTypes().Where((t) => typeof(IInstaller).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
			foreach (var installer in installers)
			{
				installer.Run(configure, service);
			}
		}
		
	}
}
