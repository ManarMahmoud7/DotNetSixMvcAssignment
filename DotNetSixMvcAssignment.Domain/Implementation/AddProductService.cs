using DotNetSixMvcAssignment.Data;
using DotNetSixMvcAssignment.Data.Models;
using DotNetSixMvcAssignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Domain.Implementation
{
    public class AddProductService : IAddProductService
    {
        private readonly IProductRepository _productRepository;

        public AddProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int Execute(ProductDto product)
        {
            return _productRepository.Add(
                new Data.Models.Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CategoryId = product.CategoryId,
                    ImgUrl = product.ImageUrl
                });
        }
    }
}
