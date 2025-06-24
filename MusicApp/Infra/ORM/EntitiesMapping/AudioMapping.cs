using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class UserMapping : BaseMapping, IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), Schema);
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);
        
        builder.Property(u => u.Name)
            .HasColumnType("varchar(200)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(u => u.JoinDate)
            .HasColumnType("datetime2")
            .HasColumnName("join_date")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.Property(u => u.ArtistId)
            .HasColumnType("bigint")
            .HasColumnName("artist_id")
            .HasColumnOrder(4);
        
        builder.HasMany(u => u.Playlists)
            .WithOne()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.Likes)
            .WithOne()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.ArtistFollows)
            .WithOne()
            .HasForeignKey(af => af.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.PlaylistFollows)
            .WithOne()
            .HasForeignKey(pf => pf.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}