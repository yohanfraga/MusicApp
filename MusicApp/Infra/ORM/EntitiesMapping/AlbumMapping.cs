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
            .HasColumnOrder(1);
        
        builder.Property(a => a.Name)
            .HasColumnType("varchar(200)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(a => a.Duration)
            .HasColumnType("int")
            .HasColumnName("duration")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.Property(a => a.IsPublic)
            .HasColumnType("bit")
            .HasColumnName("is_public")
            .HasColumnOrder(4);
        
        builder.Property(a => a.Type)
            .HasColumnType("int")
            .HasColumnName("type")
            .HasColumnOrder(5);
        
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
        
        builder.HasOne(a => a.Artist)
            .WithMany(art => art.Albums)
            .HasForeignKey(a => a.ArtistId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(a => a.Musics)
            .WithOne()
            .HasForeignKey(m => m.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}