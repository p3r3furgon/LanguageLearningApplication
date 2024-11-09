using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Learning.Domain.Models;

namespace Learning.DataAccess.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(c => c.SerialNumber).IsRequired();

            builder
                .HasMany(c => c.Domains)
                .WithOne(d => d.Chapter)
                .HasForeignKey(d => d.ChapterId)
                .IsRequired(false);
        }
    }
}
