using MediatR;
using SoftwareArchitecture.Application.Common.Interfaces;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IApplicationDbContext context;

        public CreateTodoItemHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                Title = request.Title,
                Priority = PriorityLevel.None,
                Done = false
            };

            context.TodoItems.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
