using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Domain.Entities;

namespace SoftwareArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoItem> TodoItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
