using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Application.Common.Interfaces;
using System.Threading;
using SoftwareArchitecture.Application.Common.Exceptions;
using SoftwareArchitecture.Domain.Enums;
using SoftwareArchitecture.Application.Common.Validations;

namespace SoftwareArchitecture.Application
{
    public class TodoService
    {
        private readonly IApplicationDbContext context;

        public TodoService(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TodoItem>> GetTodos()
        {
            return await context.TodoItems
                .AsNoTracking()
                .OrderBy(t => t.Priority)
                .ToListAsync();
        }

        public async Task<int> CreateTodo(string title)
        {
            TodoValidator.ValidateTitle(title);

            var entity = new TodoItem
            {
                Title = title,
                Priority = PriorityLevel.None,
                Done = false
            };

            context.TodoItems.Add(entity);

            await context.SaveChangesAsync(default);

            //Todo is id correct?

            return entity.Id;
        }

        public async Task DeleteTodo(int id)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            context.TodoItems.Remove(entity);

            await context.SaveChangesAsync(default);
        }

        public async Task UpdateTodoTitle(int id, string title)
        {
            TodoValidator.ValidateTitle(title);

            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            entity.Title = title;

            await context.SaveChangesAsync(default);
        }

        public async Task UpdateTodoDone(int id, bool done)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            entity.Done = done;

            await context.SaveChangesAsync(default);
        }

        public async Task UpdateTodoPriority(int id, PriorityLevel priority)
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
