using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDatabaseContext dbContext;
        public CategoryRepository(MyDatabaseContext myDatabaseContext)
        {
            dbContext = myDatabaseContext;
        }
        public async Task<IEnumerable<Category>> getCategories()
        {
            List<Category> categories = await dbContext.Categories.ToListAsync();
            return categories;
        }

    }
}
