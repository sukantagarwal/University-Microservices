using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Students.Core.Entities;

namespace University.Students.Infrastructure.Configurations
{
    public class StudentTypeConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.FirstName)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(r => r.LastName)
                .HasMaxLength(250)
                .IsRequired();
            
            // builder.Property(r => r.Version)
            //     .IsRequired();
            
            builder.Property(r => r.IsDeleted)
                .IsRequired();
            
            builder.Property(r => r.LastModified)
                .IsRequired();
            
            //https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities
            builder.OwnsMany(r => r.Enrollments, b =>
            {
                b.ToTable("Enrollments", "dbo")
                    .HasKey(ur => ur.Id);

                b.Property(ur => ur.Id).IsRequired().ValueGeneratedNever();

                b.Property(ur => ur.StudentId)
                    .IsRequired()
                    .UsePropertyAccessMode(PropertyAccessMode.Property);

                b.Property(ur => ur.CourseId) //TODO: FK is not generated
                    .IsRequired()
                    .UsePropertyAccessMode(PropertyAccessMode.Property);
                
                b.Property(ur => ur.Grade);
            });

            var nav = builder.Metadata.FindNavigation(nameof(Student.Enrollments));
            nav.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}