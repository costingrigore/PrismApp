using Microsoft.EntityFrameworkCore;
using PrismApp.Entities;
using System.Threading.Tasks;

namespace PrismApp
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        Task SaveAsync();
        void SetState(Product product);
    }
}