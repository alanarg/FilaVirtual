namespace FilaVirtual.AssemblyInstaller
{
    public  interface IInstaller
    {
         void Run(IConfiguration configuration, IServiceCollection serviceCollection);
    }
}
