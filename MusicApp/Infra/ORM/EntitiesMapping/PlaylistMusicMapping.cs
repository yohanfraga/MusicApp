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
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(pm => pm.PlaylistId)
            .HasColumnType("bigint")
            .HasColumnName("playlist_id")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(pm => pm.AddedDate)
            .HasColumnType("datetime2")
            .HasColumnName("added_date")
            .HasColumnOrder(3)
            .IsRequired();
    }
}