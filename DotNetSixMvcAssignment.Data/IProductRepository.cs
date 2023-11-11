using DotNetSixMvcAssignment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Data
{
    public interface IProductRepository
    {
        public int Add(Product product);

        public int Update(Product product);
        
        public int Delete(int productId);
        
        public IEnumerable<Product> GetAll();
        
        public Product GetByProductId(int productId);
    }
}
