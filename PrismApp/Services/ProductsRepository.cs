using Microsoft.EntityFrameworkCore;
using PrismApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductsRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Product> GetProductAsync(int ProductId)
        {
            return _context.Products.FirstOrDefaultAsync(c => c.ProductId == ProductId);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            if (!_context.Products.Local.Any(c => c.ProductId == product.ProductId))
            {
                _context.Products.Attach(product);
            }
            _context.SetState(product);
            await _context.SaveAsync();
            return product;

        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = _context.Products.FirstOrDefault(c => c.ProductId == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveAsync();
        }
    }
}