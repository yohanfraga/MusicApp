using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class ArtistFollowMapping : BaseMapping, IEntityTypeConfiguration<ArtistFollow>
{
    public void Configure(EntityTypeBuilder<ArtistFollow> builder)
    {
        builder.ToTable(nameof(ArtistFollow), Schema);
        builder.HasKey(f => new {f.ArtistId, f.UserId});

        builder.Property(f => f.ArtistId)
            .HasColumnType("bigint")
            .HasColumnName("artist_id")
            .HasColumnOrder(1);
        
        builder.Property(f => f.UserId)
            .HasColumnType("bigint")
            .HasColumnName("user_id")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(f => f.FollowDate)
            .HasColumnType("datetime2")
            .HasColumnName("follow_date")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.HasOne(f => f.Artist)
            .WithMany(a => a.Follows)
            .HasForeignKey(f => f.ArtistId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(f => f.User)
            .WithMany(u => u.ArtistFollows)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}