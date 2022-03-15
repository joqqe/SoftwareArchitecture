using NUnit.Framework;
using SoftwareArchitecture.Application.Common.Interfaces;
using SoftwareArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Application.IntegrationTests.TodoItems
{
    public class TodoItemServiceTests : TestBase
    {
        [Test]
        public async Task ShouldCreateTodo()
        {
            var todoService = (ITodoItemService)serviceProvider.GetService(typeof(ITodoItemService));

            var titleNewTodo = "Test todo";
            var newId = await todoService.CreateTodo(titleNewTodo);
            
            var actual = (await todoService.GetTodos())
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreSame(titleNewTodo, actual.Title);
        }
    }
}