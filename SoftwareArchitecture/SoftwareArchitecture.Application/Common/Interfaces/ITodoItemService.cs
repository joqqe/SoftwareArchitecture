using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Application.Common.Interfaces
{
    public interface ITodoItemService
    {
        Task<int> CreateTodo(string title);
        Task DeleteTodo(int id);
        Task<List<TodoItem>> GetTodos();
        Task UpdateTodoDone(int id, bool done);
        Task UpdateTodoPriority(int id, PriorityLevel priority);
        Task UpdateTodoTitle(int id, string title);
    }
}