﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(c => c.Street)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(c => c.Number)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(c => c.PostalCode)
            .IsRequired()
            .HasColumnType("varchar(8)");

        builder.Property(c => c.Complement)
            .HasColumnType("varchar(250)");

        builder.Property(c => c.Neighborhood)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(c => c.City)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(c => c.State)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.ToTable("Addresses");
    }
}
