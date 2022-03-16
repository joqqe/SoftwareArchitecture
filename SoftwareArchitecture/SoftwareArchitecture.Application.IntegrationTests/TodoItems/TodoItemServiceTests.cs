using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NUnit.Framework;
using SoftwareArchitecture.Application.Common.Interfaces;
using SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItemCommand;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;

namespace SoftwareArchitecture.Application.IntegrationTests.TodoItems
{
    public class TodoItemServiceTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateTitleOfTodo()
        {
            var todoService = (ITodoItemService)serviceProvider.GetService(typeof(ITodoItemService));
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var initialTitle = "Test todo 1";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = initialTitle
            });

            var newTitle = "Test todo 2";
            await todoService.UpdateTitle(newId, newTitle);

            var actual = (await mediator.Send(new GetTodoItemsQuery()))
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreSame(newTitle, actual.Title);
        }

        [Test]
        public async Task ShouldUpdateDoneOfTodo()
        {
            var todoService = (ITodoItemService)serviceProvider.GetService(typeof(ITodoItemService));
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var initialTitle = "Test todo";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = initialTitle
            });

            await todoService.UpdateDone(newId, true);

            var actual = (await mediator.Send(new GetTodoItemsQuery()))
                .FirstOrDefault(x => x.Id == newId);

            Assert.IsTrue(actual.Done);
        }

        [Test]
        public async Task ShouldUpdatePriorityOfTodo()
        {
            var todoService = (ITodoItemService)serviceProvider.GetService(typeof(ITodoItemService));
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var initialTitle = "Test todo";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = initialTitle
            });

            await todoService.UpdatePriority(newId, Domain.Enums.PriorityLevel.High);

            var actual = (await mediator.Send(new GetTodoItemsQuery()))
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreEqual(Domain.Enums.PriorityLevel.High, actual.Priority);
        }
    }
}