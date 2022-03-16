using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Domain.Enums;
using SoftwareArchitecture.Application.Common.Exceptions;
using SoftwareArchitecture.Application.Common.Interfaces;

namespace SoftwareArchitecture.Application.TodoItems.Commands.UpdatePriorityTodoItem
{
    public class UpdatePriorityTodoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public PriorityLevel Priority { get; set; }
    }

    public class UpdatePriorityTodoItemHandler : IRequestHandler<UpdatePriorityTodoItemCommand, Unit>
    {
        private readonly IApplicationDbContext context;

        public UpdatePriorityTodoItemHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdatePriorityTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), request.Id);

            entity.Priority = request.Priority;

            await context.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
