
using Microsoft.EntityFrameworkCore;

namespace Produto.Borders.Data
{
  public class ProductContext : DbContext
  {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<Entities.Produto> Produtos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Entities.Produto>()
                  .Property(p => p.Preco)
                  .HasColumnType("decimal(10,2)");
    }
  }
}
