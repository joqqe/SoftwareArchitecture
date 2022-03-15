using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using SoftwareArchitecture.Application.Common.Interfaces;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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