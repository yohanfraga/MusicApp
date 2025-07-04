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
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(p => p.Name)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsUnicode()
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("description")
            .HasColumnOrder(3)
            .IsUnicode()
            .IsRequired(false);
        
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
            .HasColumnOrder(6)
            .IsRequired();
        
        builder.Property(p => p.UserId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("user_id")
            .HasColumnOrder(7)
            .IsRequired();
        
        builder.HasMany(p => p.Musics)
            .WithOne(pm => pm.Playlist)
            .HasForeignKey(m => m.PlaylistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.Follows)
            .WithOne(pf => pf.Playlist)
            .HasForeignKey(pf => pf.PlaylistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Image)
            .WithOne()
            .HasForeignKey<Playlist>(p => p.ImageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}