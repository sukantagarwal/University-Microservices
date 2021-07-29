using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Cources.Core.Entities;

namespace University.Cources.Infrastructure.Configurations
{
    public class CourseTypeConfiguration: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses", "dbo");

            builder.HasKey(r => r.Id);

        }
    }
}