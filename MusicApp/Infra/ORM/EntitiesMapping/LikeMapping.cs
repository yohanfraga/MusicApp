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
            .HasColumnName("Music_id")
            .HasColumnOrder(1);
        
        builder.Property(l => l.UserId)
            .HasColumnType("bigint")
            .HasColumnName("user_id")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(l => l.LikedDate)
            .HasColumnType("datetime2")
            .HasColumnName("like_date")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.HasOne(l => l.Music)
            .WithMany(m => m.Likes)
            .HasForeignKey(l => l.MusicId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}