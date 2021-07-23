using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Departments.Core.Entities;

namespace University.Departments.Infrastructure.Configurations
{
    public class DepartmentTypeConfiguration: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Budget)
                .IsRequired();

            builder.Property(r => r.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(r => r.InstructorId);

            builder.Property(r => r.IsDeleted)
                .IsRequired();
                
            
            builder.Property(r => r.LastModified)
                .IsRequired();
            
            builder.OwnsMany(r => r.Courses, b =>
            {
                b.ToTable("Courses", "dbo")
                    .HasKey(ur => ur.Id);

                b.Property(ur => ur.DepartmentId)
                    .IsRequired()
                    .UsePropertyAccessMode(PropertyAccessMode.Property);

                
                b.Property(ur => ur.Credits);
                b.Property(ur => ur.Title);
                
            });

            var navCources = builder.Metadata.FindNavigation(nameof(Department.Courses));
            navCources.SetPropertyAccessMode(PropertyAccessMode.Field);
            
    
        }
    }
}