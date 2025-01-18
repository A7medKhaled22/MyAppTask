using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyAppTask.DAL;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("ProductTable");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Description).HasMaxLength(100);
        builder.Property(p => p.Quantity).IsRequired().HasDefaultValue(0);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasIndex(p => p.Name).IsUnique();
    }
}