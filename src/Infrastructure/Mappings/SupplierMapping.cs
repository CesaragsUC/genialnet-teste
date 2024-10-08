﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.CNPJ)
            .IsRequired()
            .HasColumnType("varchar(20)");

        // 1 : 1 => Supplier : Address
        builder.HasOne(f => f.Address)
            .WithOne(e => e.Supplier);

        // 1 : N => Supplier : Products
        builder.HasMany(f => f.SupplierProducts)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);

        builder.ToTable("Suppliers");
    }
}