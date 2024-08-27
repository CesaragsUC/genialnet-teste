using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Brand)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("varchar(1000)");



        builder.ToTable("Products");
    }
}
