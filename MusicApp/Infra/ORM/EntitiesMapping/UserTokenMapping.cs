using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class UserTokenMapping : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserToken");
        builder.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

        builder.Property(ut => ut.UserId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("user_id")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(ut => ut.LoginProvider)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("login_provider")
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(ut => ut.Name)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("name")
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(ut => ut.Value)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("value")
            .HasColumnOrder(4)
            .IsRequired(false);
    }
} 