using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SoftwareArchitecture.Application.Common.Interfaces;
using SoftwareArchitecture.Application.TodoItems;
using SoftwareArchitecture.Application.Common.Mappings;

namespace SoftwareArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITodoItemService, TodoItemService>();
            services.AddAutoMapper(typeof(TodoItemProfiles));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
