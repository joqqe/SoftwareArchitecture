using Microsoft.Extensions.DependencyInjection;

namespace SoftwareArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
