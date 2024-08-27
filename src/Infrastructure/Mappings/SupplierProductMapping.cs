using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Mappings;

public class SupplierProductMapping : IEntityTypeConfiguration<SupplierProduct>
{
    public void Configure(EntityTypeBuilder<SupplierProduct> builder)
    {
        builder.HasKey(fp => new { fp.SupplierId, fp.ProductId });


        builder.HasOne(fp => fp.Supplier)
               .WithMany(s => s.SupplierProducts)
               .HasForeignKey(fp => fp.SupplierId)
               .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(fp => fp.Product)
               .WithMany(p => p.SupplierProducts)
               .HasForeignKey(fp => fp.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

        builder.ToTable("SupplierProducts");
    }
}
