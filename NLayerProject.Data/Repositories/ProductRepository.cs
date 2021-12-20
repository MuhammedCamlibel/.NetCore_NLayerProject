using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _context.Products.Where(p => p.Id == productId).Include(p => p.Category).SingleOrDefaultAsync();
        }
    }
}
