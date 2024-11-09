using Learning.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learning.DataAccess.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.SerialNumber).IsRequired();
            builder.Property(e => e.NumberOfQuestions).IsRequired();
            builder.Property(e => e.AllowedMistakes).IsRequired();
        }
    }
}
