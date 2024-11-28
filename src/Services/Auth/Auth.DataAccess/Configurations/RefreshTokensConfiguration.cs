using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auth.Domain.Models;

namespace Auth.DataAccess.Configurations
{
    public  class RefreshTokensConfiguration: IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.UserEmail)
                .IsRequired();
        }
        
    }
}