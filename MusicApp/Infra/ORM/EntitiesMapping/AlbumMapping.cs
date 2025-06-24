using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class AlbumMapping : BaseMapping, IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable(nameof(Album), Schema);
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
        
        builder.Property(a => a.Duration)
            .HasColumnType("int")
            .HasColumnName("duration")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.Property(a => a.IsPublic)
            .HasColumnType("bit")
            .HasColumnName("is_public")
            .HasColumnOrder(4)
            .IsRequired();
        
        builder.Property(a => a.Type)
            .HasColumnType("int")
            .HasColumnName("type")
            .HasColumnOrder(5)
            .IsRequired();
        
        builder.Property(a => a.ReleaseDate)
            .HasColumnType("datetime2")
            .HasColumnName("release_date")
            .HasColumnOrder(6)
            .IsRequired();
        
        builder.Property(a => a.ArtistId).
            HasColumnType("bigint")
            .HasColumnName("artist_id")
            .HasColumnOrder(7)
            .IsRequired();
        
        builder.Property(a => a.ImageId)
            .HasColumnType("bigint")
            .HasColumnName("image_id")
            .HasColumnOrder(8)
            .IsRequired();
        
        builder.HasMany(a => a.Musics)
            .WithOne(m => m.Album)
            .HasForeignKey(m => m.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Image)
            .WithOne()
            .HasForeignKey<Album>(a => a.ImageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}