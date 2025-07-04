using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class PlaylistFollowMapping : BaseMapping, IEntityTypeConfiguration<PlaylistFollow>
{
    public void Configure(EntityTypeBuilder<PlaylistFollow> builder)
    {
        builder.ToTable(nameof(PlaylistFollow), Schema);
        builder.HasKey(f => new {f.PlaylistId, f.UserId});

        builder.Property(f => f.PlaylistId)
            .HasColumnType("bigint")
            .HasColumnName("playlist_id")
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(f => f.UserId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("user_id")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(f => f.FollowDate)
            .HasColumnType("datetime2")
            .HasColumnName("follow_date")
            .HasColumnOrder(3)
            .IsRequired();
    }
}