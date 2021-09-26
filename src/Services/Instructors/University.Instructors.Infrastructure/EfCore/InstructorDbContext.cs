using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using University.Instructors.Application;
using University.Instructors.Core.Entities;
using University.Instructors.Infrastructure.Configurations;

namespace University.Instructors.Infrastructure.EfCore
{
    public class InstructorDbContext : DbContext, IInstructorDbContext
    {
        private IDbContextTransaction _currentTransaction;

        public InstructorDbContext(DbContextOptions<InstructorDbContext> options) : base(options)
        {
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null) return;

            _currentTransaction = await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);

                await (_currentTransaction?.CommitAsync(cancellationToken) ?? Task.CompletedTask);
            }
            catch
            {
                await RollbackTransaction(cancellationToken);
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransaction(CancellationToken cancellationToken)
        {
            try
            {
                await _currentTransaction!.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new InstructorTypeConfiguration());
        }
    }
}