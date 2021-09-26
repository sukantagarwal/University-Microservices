using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Cources.Core.Entities;

namespace University.Cources.Infrastructure.Configurations
{
    public class CourseTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Credits)
                .IsRequired();

            builder.Property(r => r.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.DepartmentId);

            // builder.Property(r => r.Version)
            //     .IsRequired();

            builder.Property(r => r.IsDeleted)
                .IsRequired();

            builder.Property(r => r.LastModified)
                .IsRequired();
        }
    }
}