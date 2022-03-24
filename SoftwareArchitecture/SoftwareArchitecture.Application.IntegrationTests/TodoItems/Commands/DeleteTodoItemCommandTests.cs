using MediatR;
using NUnit.Framework;
using SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using SoftwareArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Application.IntegrationTests.TodoItems.Commands
{
    public class DeleteTodoItemCommandTests : TestBase
    {
        [Test]
        public async Task ShouldDeleteTodo()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var newTitle = "Test todo";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = newTitle
            });

            await mediator.Send(new DeleteTodoItemCommand
            {
                Id = newId
            });

            var actual = await mediator.Send(new GetTodoItemsQuery());

            Assert.IsNull(actual.FirstOrDefault(t => t.Id == newId));
        }
    }
}
