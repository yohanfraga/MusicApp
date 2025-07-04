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
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(m => m.Name)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsUnicode()
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
        
        builder.HasMany(m => m.Likes)
            .WithOne(l => l.Music)
            .HasForeignKey(l => l.MusicId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(m => m.Playlists)
            .WithOne(pm => pm.Music)
            .HasForeignKey(pm => pm.MusicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}