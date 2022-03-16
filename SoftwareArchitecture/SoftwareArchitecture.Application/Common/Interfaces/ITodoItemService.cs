using System.Threading.Tasks;
using SoftwareArchitecture.Domain.Enums;

namespace SoftwareArchitecture.Application.Common.Interfaces
{
    public interface ITodoItemService
    {
        Task<int> Create(string title);
        Task Delete(int id);
        Task UpdateDone(int id, bool done);
        Task UpdatePriority(int id, PriorityLevel priority);
        Task UpdateTitle(int id, string title);
    }
}