using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NUnit.Framework;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;
using SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using SoftwareArchitecture.Application.TodoItems.Commands.UpdateTitleTodoItem;
using SoftwareArchitecture.Application.TodoItems.Commands.UpdateDoneTodoItem;

namespace SoftwareArchitecture.Application.IntegrationTests.TodoItems.Commands
{
    public class UpdateDoneTodoItemCommandTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateDoneOfTodo()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var initialTitle = "Test todo";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = initialTitle
            });

            await mediator.Send(new UpdateDoneTodoItemCommand
            { 
                 Id = newId,
                 Done = true
            });

            var actual = (await mediator.Send(new GetTodoItemsQuery()))
                .FirstOrDefault(x => x.Id == newId);

            Assert.IsTrue(actual.Done);
        }
    }
}
