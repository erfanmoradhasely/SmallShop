using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallShop.Domain.ProductAgg;

namespace SmallShop.Infrastructure.Persistence.ProductAgg;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "product");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.UserId)
            .IsRequired();

        builder.Property(b => b.ProductionDate)
            .IsRequired();


        builder.OwnsOne(b => b.ManufacturerPhoneNumber, option =>
        {
            option.Property(b => b.Value)
                  .IsRequired()
                  .HasMaxLength(11)
                  .IsUnicode(false)
                  .HasColumnName("ManufacturerPhoneNumber");

        });

        builder.OwnsOne(b => b.ManufacturerEmail, option =>
        {
            option.Property(b => b.Value)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false)
                  .HasColumnName("ManufacturerPhoneNumber");

        });

        builder.HasIndex(b => new { b.ProductionDate, b.ManufacturerEmail }).IsUnique();

    }
}