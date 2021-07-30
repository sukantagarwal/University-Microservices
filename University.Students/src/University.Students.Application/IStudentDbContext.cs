using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Students.Core.Entities;

namespace University.Students.Application
{
    public interface IStudentDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransaction(CancellationToken cancellationToken);
    }
}