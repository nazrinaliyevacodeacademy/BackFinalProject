﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final.Persistence.Configuration
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
            public void Configure(EntityTypeBuilder<Medicine> builder)
            {
                builder.HasKey(m => m.Id);

                builder.Property(m => m.Name)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(m => m.Dosage)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.Property(m => m.Category)
                       .HasMaxLength(50);

                builder.Property(m => m.Price)
                       .HasColumnType("decimal(18,2)")
                       .IsRequired();

                builder.Property(m => m.Stock)
                       .IsRequired();

                builder.Property(m => m.Manufacturer)
                       .HasMaxLength(100);

                builder.Property(m => m.ExpirationDate)
                       .IsRequired();

                builder.Property(m => m.ImageUrl)
                       .HasMaxLength(200);
            }
        
    }

}

