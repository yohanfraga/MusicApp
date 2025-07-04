using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("UserLogin");
        builder.HasKey(ul => new { ul.ProviderKey, ul.LoginProvider });

        builder.Property(ul => ul.ProviderKey)
            .HasColumnType("nvarchar(450)")
            .HasColumnName("provider_key")
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(ul => ul.LoginProvider)
            .HasColumnType("nvarchar(450)")
            .HasColumnName("login_provider")
            .ValueGeneratedOnAdd()
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(ul => ul.UserId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("user_id")
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(ul => ul.ProviderDisplayName)
            .HasColumnType("nvarchar(450)")
            .HasColumnName("provider_display_name")
            .HasColumnOrder(3)
            .IsRequired(false);
    }
} 