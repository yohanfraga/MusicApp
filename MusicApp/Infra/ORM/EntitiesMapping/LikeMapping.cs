using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class LikeMapping : BaseMapping, IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable(nameof(Like), Schema);
        builder.HasKey(l => new {l.MusicId, l.UserId});

        builder.Property(l => l.MusicId)
            .HasColumnType("bigint")
            .HasColumnName("music_id")
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(l => l.UserId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("user_id")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(l => l.LikedDate)
            .HasColumnType("datetime2")
            .HasColumnName("like_date")
            .HasColumnOrder(3)
            .IsRequired();
    }
}