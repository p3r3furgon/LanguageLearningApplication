using Learning.Domain.Models.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learning.DataAccess.Configurations
{
    public class MediaQustionConfiguration : IEntityTypeConfiguration<MediaQuestion>
    {
        public void Configure(EntityTypeBuilder<MediaQuestion> builder)
        {
            builder.OwnsOne(m => m.FileOptions, fileOptionsBuilder =>
            {
                fileOptionsBuilder.Property(f => f.Name).IsRequired();
                fileOptionsBuilder.Property(f => f.PresignedUrl).IsRequired();
                fileOptionsBuilder.Property(f => f.ExpiriedAt).IsRequired();
            });
            builder.Property(q => q.MediaType).HasConversion<string>();
        }
    }
}
