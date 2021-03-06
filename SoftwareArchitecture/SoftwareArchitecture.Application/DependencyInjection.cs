using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MediatR.Pipeline;
using SoftwareArchitecture.Application.Common.Mappings;
using SoftwareArchitecture.Application.Common.Logging;

namespace SoftwareArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TodoItemProfiles));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            return services;
        }
    }
}
