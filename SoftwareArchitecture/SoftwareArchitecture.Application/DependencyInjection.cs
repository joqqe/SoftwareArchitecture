using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SoftwareArchitecture.Application.Common.Mappings;

namespace SoftwareArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TodoItemProfiles));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
