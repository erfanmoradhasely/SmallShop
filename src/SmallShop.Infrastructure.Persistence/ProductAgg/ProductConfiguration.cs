using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmallShop.Domain.Common.ValueObjects;
using SmallShop.Domain.ProductAgg;

namespace SmallShop.Infrastructure.Persistence.ProductAgg;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    private ValueConverter emailConverter = new ValueConverter<Email, string>(t => t.Value, t => new Email(t));
    private ValueConverter phoneNumberConverter = new ValueConverter<PhoneNumber, string>(t => t.Value, t => new PhoneNumber(t));

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

        //builder.Property<string>("ManufacturerEmail");
        builder.Property(b => b.ManufacturerEmail)
            .HasConversion(emailConverter)
            .HasColumnName("ManufacturerEmail")
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);

        builder.Property(b => b.ManufacturerPhoneNumber)
            .HasConversion(phoneNumberConverter)
             .HasColumnName("ManufacturerPhoneNumber")
                  .IsRequired()
                  .HasMaxLength(11)
                  .IsUnicode(false);
                 


        builder.HasIndex("ProductionDate", "ManufacturerEmail");

    }
}