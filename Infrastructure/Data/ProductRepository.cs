using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                        .Include(o => o.ProductBrand)
                        .Include(o => o.ProductType)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                        .Include(o => o.ProductBrand)
                        .Include(o => o.ProductType)
                        .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync()
        {
            return await _context.ProductsBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
        {
            return await _context.ProductsTypes.ToListAsync();
        }
    }
}