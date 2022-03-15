using Microsoft.Extensions.DependencyInjection;
using SoftwareArchitecture.Application.TodoItems;
using SoftwareArchitecture.Application.Common.Interfaces;

namespace SoftwareArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITodoItemService, TodoItemService>();

            return serviceCollection;
        }
    }
}
