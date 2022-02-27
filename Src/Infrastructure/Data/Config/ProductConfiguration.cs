using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Validation Config

            builder.Property(x => x.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(500);

            builder.Property(x => x.Price)
                    .HasColumnType("decimal(18,2)");

            //Navigation Config
            builder.HasOne(x => x.Brand)
                    .WithMany()
                      .HasForeignKey(x => x.BrandId);

            builder.HasOne(x => x.Category)
                    .WithMany()
                      .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Pictures).WithOne(x => x.Product);
        }
    }
}
