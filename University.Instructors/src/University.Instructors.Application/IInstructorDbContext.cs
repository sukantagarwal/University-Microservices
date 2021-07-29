using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Instructors.Core.Entities;

namespace University.Instructors.Application
{
    public interface IInstructorDbContext
    {
        DbSet<Instructor> Instructors { get; set; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransaction(CancellationToken cancellationToken);
    }
}