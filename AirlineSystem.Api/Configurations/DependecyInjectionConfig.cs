using AirlineSystem.IoC;

namespace AirlineSystem.Api.Configurations
{
    public static class DependecyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            DependencyContainer.RegisterServices(services);


        }
    }
}
