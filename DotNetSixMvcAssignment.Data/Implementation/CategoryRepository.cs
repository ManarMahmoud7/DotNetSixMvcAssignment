using DotNetSixMvcAssignment.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Data.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private ProductsDbContext _dbContext;

        public CategoryRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
