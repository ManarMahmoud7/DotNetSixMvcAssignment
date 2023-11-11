using DotNetSixMvcAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Domain.Implementation
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int Execute(int productId)
        {
            return _productRepository.Delete(productId);
        }
    }
}
