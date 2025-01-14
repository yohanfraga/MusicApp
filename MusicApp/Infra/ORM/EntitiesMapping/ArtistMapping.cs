using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class ArtistMapping : BaseMapping, IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable(nameof(Artist), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);
        
        builder.Property(a => a.Name)
            .HasColumnType("varchar(200)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(a => a.JoinDate)
            .HasColumnType("datetime2")
            .HasColumnName("join_date")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.HasMany(a => a.Albums)
            .WithOne()
            .HasForeignKey(al => al.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(a => a.Follows)
            .WithOne()
            .HasForeignKey(f => f.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}