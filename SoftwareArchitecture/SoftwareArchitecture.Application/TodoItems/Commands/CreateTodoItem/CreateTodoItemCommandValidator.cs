using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using SoftwareArchitecture.Application.Common.Validations;

namespace SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator<TRequest> : IRequestPreProcessor<TRequest> where TRequest : CreateTodoItemCommand
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            TodoItemValidator.Title(request.Title);

            return Task.CompletedTask;
        }
    }
}
