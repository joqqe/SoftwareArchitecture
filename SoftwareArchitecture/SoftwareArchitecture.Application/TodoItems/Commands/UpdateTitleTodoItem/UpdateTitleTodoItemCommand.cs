using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoftwareArchitecture.Application.Common.Exceptions;
using SoftwareArchitecture.Application.Common.Interfaces;
using SoftwareArchitecture.Application.Common.Validations;
using SoftwareArchitecture.Domain.Entities;

namespace SoftwareArchitecture.Application.TodoItems.Commands.UpdateTitleTodoItem
{
    public class UpdateTitleTodoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class UpdateTitleTodoItemHandler : IRequestHandler<UpdateTitleTodoItemCommand, Unit>
    {
        private readonly IApplicationDbContext context;

        public UpdateTitleTodoItemHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateTitleTodoItemCommand request, CancellationToken cancellationToken)
        {

            var entity = await context.TodoItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), request.Id);

            entity.Title = request.Title;

            await context.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
