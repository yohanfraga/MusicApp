using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class MusicMapping : BaseMapping, IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.ToTable(nameof(Music), Schema);
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);
        
        builder.Property(m => m.Name)
            .HasColumnType("varchar(200)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(m => m.Duration)
            .HasColumnType("int")
            .HasColumnName("duration")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.Property(m => m.IsPublic)
            .HasColumnType("bit")
            .HasColumnName("is_public")
            .HasColumnOrder(4);
        
        builder.Property(m => m.ReleaseDate)
            .HasColumnType("datetime2")
            .HasColumnName("release_date")
            .HasColumnOrder(5)
            .IsRequired();
        
        builder.HasOne(m => m.Album)
            .WithMany(a => a.Musics)
            .HasForeignKey(m => m.AlbumId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(m => m.Likes)
            .WithOne()
            .HasForeignKey(l => l.MusicId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.Playlists)
            .WithOne()
            .HasForeignKey(pm => pm.MusicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}