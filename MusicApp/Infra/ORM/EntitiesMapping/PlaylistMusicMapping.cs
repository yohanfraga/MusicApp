using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class PlaylistMusicMapping : BaseMapping, IEntityTypeConfiguration<PlaylistMusic>
{
    public void Configure(EntityTypeBuilder<PlaylistMusic> builder)
    {
        builder.ToTable(nameof(PlaylistMusic), Schema);
        builder.HasKey(pm => new {pm.MusicId, pm.PlaylistId});

        builder.Property(pm => pm.MusicId)
            .HasColumnType("bigint")
            .HasColumnName("music_id")
            .HasColumnOrder(1);
        
        builder.Property(pm => pm.PlaylistId)
            .HasColumnType("bigint")
            .HasColumnName("playlist_id")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.HasOne(pm => pm.Music)
            .WithMany(m => m.Playlists)
            .HasForeignKey(pm => pm.MusicId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(pm => pm.Playlist)
            .WithMany(p => p.Musics)
            .HasForeignKey(pm => pm.PlaylistId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}