using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public sealed class AudioMapping : BaseMapping, IEntityTypeConfiguration<Audio>
{
    public void Configure(EntityTypeBuilder<Audio> builder)
    {
        builder.ToTable(nameof(Audio), Schema);
        builder.Property(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(a => a.Name)
            .HasColumnType("nvarchar(255)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsUnicode()
            .IsRequired();

        builder.Property(a => a.Extension)
            .HasColumnType("nvarchar(10)")
            .HasColumnName("extension")
            .HasColumnOrder(3)
            .IsUnicode()
            .IsRequired();

        builder.Property(a => a.Bytes)
            .HasColumnType("varbinary(max)")
            .HasColumnName("bytes")
            .HasColumnOrder(4)
            .IsRequired();
    }
}