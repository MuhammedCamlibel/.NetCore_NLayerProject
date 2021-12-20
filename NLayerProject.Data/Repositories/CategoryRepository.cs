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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationDbContext context) : base (context)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _context.Categories.Where(c => c.Id == categoryId).Include(c => c.Products).SingleOrDefaultAsync();
        }
    }
}
