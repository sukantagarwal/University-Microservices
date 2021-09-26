using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using University.Cources.Application;
using University.Cources.Core.Entities;
using University.Cources.Infrastructure.Configurations;

namespace University.Cources.Infrastructure.EfCore
{
    public class CourseDbContext : DbContext, ICourseDbContext
    {
        private IDbContextTransaction _currentTransaction;

        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

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
            builder.ApplyConfiguration(new CourseTypeConfiguration());
        }
    }
}