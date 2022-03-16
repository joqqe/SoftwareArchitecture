using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NUnit.Framework;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;
using SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItemCommand;

namespace SoftwareArchitecture.Application.IntegrationTests.TodoItems.Commands
{
    public class CreateTodoItemCommandTests : TestBase
    {
        [Test]
        public async Task ShouldCreateTodo()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var newTitle = "Test todo";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = newTitle
            });

            var actual = (await mediator.Send(new GetTodoItemsQuery()))
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreSame(newTitle, actual.Title);
        }
    }
}
