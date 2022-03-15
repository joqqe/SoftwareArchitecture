using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Domain.Entities;
using SoftwareArchitecture.Application.Common.Interfaces;

namespace SoftwareArchitecture.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("SoftwareArchitectureDb");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>()
                .HasKey(t => t.Id);
            builder.Entity<TodoItem>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<TodoItem>()
                .Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
