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

            var newTitle = "Test todo";
            var newId = await todoService.CreateTodo(newTitle);
            
            var actual = (await todoService.GetTodos())
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreSame(newTitle, actual.Title);
        }

        [Test]
        public async Task ShouldUpdateTitleOfTodo()
        {
            var todoService = (ITodoItemService)serviceProvider.GetService(typeof(ITodoItemService));

            var initialTitle = "Test todo 1";
            var newId = await todoService.CreateTodo(initialTitle);

            var newTitle = "Test todo 2";
            await todoService.UpdateTodoTitle(newId, newTitle);

            var actual = (await todoService.GetTodos())
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreSame(newTitle, actual.Title);
        }

        [Test]
        public async Task ShouldUpdateDoneOfTodo()
        {
            var todoService = (ITodoItemService)serviceProvider.GetService(typeof(ITodoItemService));

            var initialTitle = "Test todo";
            var newId = await todoService.CreateTodo(initialTitle);

            await todoService.UpdateTodoDone(newId, true);

            var actual = (await todoService.GetTodos())
                .FirstOrDefault(x => x.Id == newId);

            Assert.IsTrue(actual.Done);
        }

        [Test]
        public async Task ShouldUpdatePriorityOfTodo()
        {
            var todoService = (ITodoItemService)serviceProvider.GetService(typeof(ITodoItemService));

            var initialTitle = "Test todo";
            var newId = await todoService.CreateTodo(initialTitle);

            await todoService.UpdateTodoPriority(newId, Domain.Enums.PriorityLevel.High);

            var actual = (await todoService.GetTodos())
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreEqual(Domain.Enums.PriorityLevel.High, actual.Priority);
        }
    }
}