using System.Threading.Tasks;
using System.Collections.Generic;
using SoftwareArchitecture.Domain.Enums;
using SoftwareArchitecture.Domain.Entities;

namespace SoftwareArchitecture.Application.Common.Interfaces
{
    public interface ITodoItemService
    {
        Task<int> Create(string title);
        Task Delete(int id);
        Task<List<TodoItem>> GetAll();
        Task UpdateDone(int id, bool done);
        Task UpdatePriority(int id, PriorityLevel priority);
        Task UpdateTitle(int id, string title);
    }
}