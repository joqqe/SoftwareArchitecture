using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using SoftwareArchitecture.Application.Common.Interfaces;

namespace SoftwareArchitecture.Application.TodoItems.Queries.GetTodoItems
{
    public class GetTodoItemsQuery : IRequest<List<GetTodoItemDto>>
    {
    }

    public class GetTodoItemsHandler : IRequestHandler<GetTodoItemsQuery, List<GetTodoItemDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetTodoItemsHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GetTodoItemDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<GetTodoItemDto>>(
                await context.TodoItems
                    .AsNoTracking()
                    .OrderBy(t => t.Priority)
                    .ToListAsync());
        }
    }
}
