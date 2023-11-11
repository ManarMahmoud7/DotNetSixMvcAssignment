using DotNetSixMvcAssignment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private ProductsDbContext _dbContext;

        public ProductRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Product product)
        {
            if (product == null)
                return 0;

            _dbContext.Products.Add(product);

            return _dbContext.SaveChanges();
        }

        public int Delete(int productId)
        {
            var productTobeDeleted = GetByProductId(productId);

            if (productTobeDeleted == null)
                return 0;

            _dbContext.Remove(productTobeDeleted);

            return _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product? GetByProductId(int productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == productId);                     
        }

        public int Update(Product product)
        {
            if(product == null) 
                   return 0;
            _dbContext.Products.Update(product);
            
            return _dbContext.SaveChanges();
        }
    }
}
