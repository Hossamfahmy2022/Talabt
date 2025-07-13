using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabt.Core.Entities;

namespace Talabt.Repositery.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // has index , max lenght
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.PictureUrl).HasMaxLength(250);
            //  price is decimal 
            builder.Property(x => x.Price).HasColumnType("decimal (18,2)");
            // relation between product and ProducrtBrand
            builder.HasOne(x => x.Brand)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.BrandId).HasConstraintName("BrandId");

            // relation between product and ProductCatergory
            builder.HasOne(x => x.catergory)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.CatergoryId).HasConstraintName("catergoryId");
        }
    }
}
