using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NUnit.Framework;
using SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems;

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

        [Test]
        public async Task ShouldThrowValidationException()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var newTitle = "Test todo Test todo Test todo Test todo Test todo Test todo Test todo" +
                "Test todo Test todo Test todo Test todo Test todo Test todo Test todo Test todo" +
                "Test todo Test todo Test todo Test todo Test todo Test todo Test todo Test todo";
            
            var ex = Assert.ThrowsAsync<ValidationException>(async () => await mediator.Send(new CreateTodoItemCommand
            {
                Title = newTitle
            }));

            Assert.AreSame(ex.Message, "Title should not exceed a character count of 200");
        }
    }
}
