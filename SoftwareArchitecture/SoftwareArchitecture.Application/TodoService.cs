using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Application.Common.Interfaces;
using System.Threading;
using SoftwareArchitecture.Application.Common.Exceptions;
using SoftwareArchitecture.Domain.Enums;

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
                .OrderBy(t => t.Title)
                .ToListAsync();
        }

        public async Task<int> CreateTodo(string title)
        {
            var entity = new TodoItem
            {
                Title = title,
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

        public async Task UpdateTodo(int id, string title, bool done)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            entity.Title = title;
            entity.Done = done;

            await context.SaveChangesAsync(default);
        }

        public async Task UpdateTodoDetails(int id, string note, PriorityLevel priority)
        {
            var entity = await context.TodoItems
                .FindAsync(new object[] { id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(TodoItem), id);

            entity.Priority = priority;
            entity.Note = note;

            await context.SaveChangesAsync(default);

        }
    }
}
