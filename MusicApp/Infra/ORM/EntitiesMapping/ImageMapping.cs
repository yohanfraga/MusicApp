using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class ImageMapping : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable(nameof(Image));
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(i => i.Name)
            .HasColumnType("nvarchar(255)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsUnicode()
            .IsRequired();

        builder.Property(i => i.Extension)
            .HasColumnType("nvarchar(10)")
            .HasColumnName("extension")
            .HasColumnOrder(3)
            .IsUnicode()
            .IsRequired();

        builder.Property(i => i.Bytes)
            .HasColumnType("varbinary(max)")
            .HasColumnName("bytes")
            .HasColumnOrder(4)
            .IsRequired();
    }
} 