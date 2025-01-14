using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class PlaylistMapping : BaseMapping, IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.ToTable(nameof(Playlist), Schema);
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);
        
        builder.Property(p => p.Name)
            .HasColumnType("varchar(200)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasColumnType("varchar(200)")
            .HasColumnName("description")
            .HasColumnOrder(3);
        
        builder.Property(p => p.CreateDate)
            .HasColumnType("datetime2")
            .HasColumnName("create_date")
            .HasColumnOrder(4)
            .IsRequired();
        
        builder.Property(p => p.Duration)
            .HasColumnType("int")
            .HasColumnName("duration")
            .HasColumnOrder(5)
            .IsRequired();
        
        builder.Property(p => p.IsPublic)
            .HasColumnType("bit")
            .HasColumnName("is_public")
            .HasColumnOrder(6);
        
        builder.Property(p => p.UserId)
            .HasColumnType("bigint")
            .HasColumnName("user_id")
            .HasColumnOrder(7);
        
        builder.HasOne(p => p.User)
            .WithMany(u => u.Playlists)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(p => p.Musics)
            .WithOne()
            .HasForeignKey(m => m.PlaylistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}