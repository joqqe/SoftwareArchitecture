using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NUnit.Framework;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;
using SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItemCommand;
using SoftwareArchitecture.Application.TodoItems.Commands.UpdateTitleTodoItem;
using SoftwareArchitecture.Application.TodoItems.Commands.UpdatePriorityTodoItem;

namespace SoftwareArchitecture.Application.IntegrationTests.TodoItems.Commands
{
    public class UpdatePriorityTodoItemCommandTests : TestBase
    {
        [Test]
        public async Task ShouldUpdatePriorityOfTodo()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var initialTitle = "Test todo";
            var newId = await mediator.Send(new CreateTodoItemCommand
            {
                Title = initialTitle
            });

            await mediator.Send(new UpdatePriorityTodoItemCommand
            {
                Id = newId,
                Priority = Domain.Enums.PriorityLevel.High
            });

            var actual = (await mediator.Send(new GetTodoItemsQuery()))
                .FirstOrDefault(x => x.Id == newId);

            Assert.AreEqual(Domain.Enums.PriorityLevel.High, actual.Priority);
        }
    }
}
