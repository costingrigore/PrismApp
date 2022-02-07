using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrismApp.Entities;
using System.Threading.Tasks;

namespace PrismApp
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        }

        public async Task SaveAsync()
        {
            await this.SaveChangesAsync();
        }


        public void SetState(Product product)
        {
            this.Entry(product).State = EntityState.Modified;
        }
    }
}
