﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Models;
using System;
using System.Collections.Generic;

namespace ProyectoDefinitvo___Northwind.Data.Configurations
{
    public partial class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.HomePage).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Supplier> entity);
    }
}
