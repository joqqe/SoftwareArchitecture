using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NUnit.Framework;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;
using SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItemCommand;
using SoftwareArchitecture.Application.TodoItems.Commands.UpdateTitleTodoItem;

namespace SoftwareArchitecture.Application.IntegrationTests.TodoItems.Commands
{
    public class UpdateTitleTodoItemCommandTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateTitleOfTodo()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var initialTitle = "Test todo 1";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = initialTitle
            });

            var newTitle = "Test todo 2";
            await mediator.Send(new UpdateTitleTodoItemCommand
            {
                Id = newId,
                Title = newTitle
            });

            var actual = (await mediator.Send(new GetTodoItemsQuery()))
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreSame(newTitle, actual.Title);
        }
    }
}
