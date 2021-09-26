using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Departments.Core.Entities;

namespace University.Departments.Application
{
    public interface IDepartmentDbContext
    {
        DbSet<Department> Departments { get; set; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransaction(CancellationToken cancellationToken);
    }
}