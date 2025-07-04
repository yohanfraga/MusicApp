using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(r => r.Name)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("name");

        builder.Property(r => r.NormalizedName)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("normalized_name");

        builder.Property(r => r.Active)
            .HasColumnType("bit")
            .HasColumnName("active")
            .IsRequired();

        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 