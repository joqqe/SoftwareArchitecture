using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Application.Common.Exceptions;
using SoftwareArchitecture.Application.Common.Interfaces;

namespace SoftwareArchitecture.Application.TodoItems.Commands.UpdateDoneTodoItem
{

    public class UpdateDoneTodoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Done { get; set; }
    }

    public class UpdateDoneTodoItemHandler : IRequestHandler<UpdateDoneTodoItemCommand, Unit>
    {
        private readonly IApplicationDbContext context;

        public UpdateDoneTodoItemHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateDoneTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), request.Id);

            entity.Done = request.Done;

            await context.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
