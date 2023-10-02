using System.Reflection;

namespace FilaVirtual.AssemblyUse
{
    public static class UseHelper
    {
		public static void UseServices(this WebApplication app, IWebHostEnvironment env)
		{
			var installers = Assembly.GetExecutingAssembly().GetTypes().Where((t) => typeof(IUse).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).Select(Activator.CreateInstance).Cast<IUse>().ToList();
			foreach (var installer in installers)
			{
				installer.Use(app, env);
			}
		}
	}
}
