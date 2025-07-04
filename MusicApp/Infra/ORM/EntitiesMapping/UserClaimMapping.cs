using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class UserClaimMapping : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaim");
        builder.HasKey(uc => uc.Id);

        builder.Property(uc => uc.Id)
            .HasColumnType("int")
            .HasColumnName("id")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(uc => uc.UserId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("user_id")
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(uc => uc.ClaimType)
            .HasColumnType("varchar(256)")
            .HasColumnName("claim_type")
            .HasColumnOrder(2)
            .IsRequired(false);

        builder.Property(uc => uc.ClaimValue)
            .HasColumnType("varchar(256)")
            .HasColumnName("claim_value")
            .HasColumnOrder(3)
            .IsRequired(false);
    }
} 