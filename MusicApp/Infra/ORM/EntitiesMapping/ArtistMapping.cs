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
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(a => a.Name)
            .HasColumnType("nvarchar(255)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsUnicode()
            .IsRequired();
        
        builder.Property(a => a.JoinDate)
            .HasColumnType("datetime2")
            .HasColumnName("join_date")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.Property(a => a.ImageId)
            .HasColumnType("bigint")
            .HasColumnName("image_id")
            .HasColumnOrder(4)
            .IsRequired();
        
        builder.HasMany(a => a.Albums)
            .WithOne(al => al.Artist)
            .HasForeignKey(al => al.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(a => a.Follows)
            .WithOne(f => f.Artist)
            .HasForeignKey(f => f.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Image)
            .WithOne()
            .HasForeignKey<Artist>(a => a.ImageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}