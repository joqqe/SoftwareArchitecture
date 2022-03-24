using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using SoftwareArchitecture.Application.Common.Validations;

namespace SoftwareArchitecture.Application.TodoItems.Commands.UpdateTitleTodoItem
{
    public class UpdateTitleTodoItemCommandValidator<TRequest> : IRequestPreProcessor<TRequest> where TRequest : UpdateTitleTodoItemCommand
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            TodoItemValidator.Title(request.Title);

            return Task.CompletedTask;
        }
    }
}
