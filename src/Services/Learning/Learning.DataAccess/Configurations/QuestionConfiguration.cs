using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Learning.Domain.Models.Questions;

namespace Learning.DataAccess.Configurations
{
    public class QustionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.HasKey(q => q.Id);

            builder.Property(c => c.Condition)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(q => q.Explanation)
                .HasMaxLength(1500);

            builder.Property(q => q.Answer)
                .HasMaxLength(1500)
                .IsRequired();
        }
    }
}
