using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Domain.Enums;
using SoftwareArchitecture.Application.Common.Interfaces;
using SoftwareArchitecture.Application.Common.Exceptions;
using SoftwareArchitecture.Application.Common.Validations;

namespace SoftwareArchitecture.Application.TodoItems
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IApplicationDbContext context;

        public TodoItemService(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await context.TodoItems
                .AsNoTracking()
                .OrderBy(t => t.Priority)
                .ToListAsync();
        }

        public async Task<int> Create(string title)
        {
            TodoItemValidator.Title(title);

            var entity = new TodoItem
            {
                Title = title,
                Priority = PriorityLevel.None,
                Done = false
            };

            context.TodoItems.Add(entity);

            await context.SaveChangesAsync(default);

            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            context.TodoItems.Remove(entity);

            await context.SaveChangesAsync(default);
        }

        public async Task UpdateTitle(int id, string title)
        {
            TodoItemValidator.Title(title);

            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            entity.Title = title;

            await context.SaveChangesAsync(default);
        }

        public async Task UpdateDone(int id, bool done)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            entity.Done = done;

            await context.SaveChangesAsync(default);
        }

        public async Task UpdatePriority(int id, PriorityLevel priority)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            entity.Priority = priority;

            await context.SaveChangesAsync(default);
        }
    }
}
