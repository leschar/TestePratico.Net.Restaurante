using Microsoft.Extensions.DependencyInjection;
using TestePratico.Net.Restaurante.IoC;

namespace TestePratico.Net.Restaurante.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
