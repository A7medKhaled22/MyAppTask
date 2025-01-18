using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTask.DAL;

public class ProductContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);

    }
}