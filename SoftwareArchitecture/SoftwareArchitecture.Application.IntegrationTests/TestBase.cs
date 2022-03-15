using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SoftwareArchitecture.Infrastructure.Persistence;

namespace SoftwareArchitecture.Application.IntegrationTests
{
    public class TestBase
    {
        public ServiceProvider serviceProvider;
        public IServiceScopeFactory scopeFactory;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            Application.DependencyInjection.AddApplication(services);
            Infrastructure.DependencyInjection.AddInfrastructure(services);

            serviceProvider = services.BuildServiceProvider();
            scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

            EnsureDatabase();
        }

        private void EnsureDatabase()
        {
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.EnsureCreated();
        }
    }
}