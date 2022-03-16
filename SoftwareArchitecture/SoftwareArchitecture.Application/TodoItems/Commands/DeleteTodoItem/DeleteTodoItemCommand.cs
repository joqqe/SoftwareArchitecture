using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Application.Common.Exceptions;
using SoftwareArchitecture.Application.Common.Interfaces;

namespace SoftwareArchitecture.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, Unit>
    {
        private readonly IApplicationDbContext context;

        public DeleteTodoItemHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), request.Id);

            context.TodoItems.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
