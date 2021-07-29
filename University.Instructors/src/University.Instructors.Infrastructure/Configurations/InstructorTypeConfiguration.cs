using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Instructors.Core.Entities;

namespace University.Instructors.Infrastructure.Configurations
{
    public class InstructorTypeConfiguration: IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors", "dbo");

            builder.HasKey(r => r.Id);

        }
    }
}