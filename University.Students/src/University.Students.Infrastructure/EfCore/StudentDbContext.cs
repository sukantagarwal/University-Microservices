using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using University.Students.Application;
using University.Students.Core.Entities;
using University.Students.Infrastructure.Configurations;

namespace University.Students.Infrastructure.EfCore
{
    public class StudentDbContext: DbContext, IStudentDbContext
    {
         private IDbContextTransaction _currentTransaction;

         public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
         {
         }
        
         public DbSet<Student> Students { get; set; }
         
        
         protected override void OnModelCreating(ModelBuilder builder)
         {
             builder.ApplyConfiguration(new StudentTypeConfiguration());
         }
        
        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

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
    }
}