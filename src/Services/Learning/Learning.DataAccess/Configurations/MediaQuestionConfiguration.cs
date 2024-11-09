using Learning.Domain.Models.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learning.DataAccess.Configurations
{
    public class MediaQustionConfiguration : IEntityTypeConfiguration<MediaQuestion>
    {
        public void Configure(EntityTypeBuilder<MediaQuestion> builder)
        {
            builder.Property(q => q.MediaType).HasConversion<string>();
            builder.Property(q => q.MediaFileName).IsRequired();
        }
    }
}
