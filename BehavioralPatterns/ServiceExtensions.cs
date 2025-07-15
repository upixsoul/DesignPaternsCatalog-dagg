using Microsoft.Extensions.DependencyInjection;

namespace BehavioralPatterns
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            // Example: Add custom services
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


            return services;
        }
    }
}
