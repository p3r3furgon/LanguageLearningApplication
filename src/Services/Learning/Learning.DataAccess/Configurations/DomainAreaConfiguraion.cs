using Learning.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learning.DataAccess.Configurations
{
    public class DomainAreaConfiguraion : IEntityTypeConfiguration<DomainArea>
    {
        public void Configure(EntityTypeBuilder<DomainArea> builder)
        {

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(d => d.SerialNumber).IsRequired();

            builder
                .HasMany(d => d.Tests)
                .WithOne(t => t.Domain)
                .HasForeignKey(t => t.DomainId)
                .IsRequired(false);

            builder
                .HasMany(d => d.Questions)
                .WithOne(q => q.Domain)
                .HasForeignKey(q => q.DomainId)
                .IsRequired(false);
        }
    }
}
