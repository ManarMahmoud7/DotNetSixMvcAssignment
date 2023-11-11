using DotNetSixMvcAssignment.Data;
using DotNetSixMvcAssignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Domain.Implementation
{
    public class UpdateProductService : IUpdateProductService
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int Execute(ProductDto product)
        {
            var toBeEditedProduct = _productRepository.GetByProductId(product.Id);
            if (toBeEditedProduct == null) return 0;

            toBeEditedProduct.Price = product.Price;
            toBeEditedProduct.Quantity = product.Quantity;  
            toBeEditedProduct.Name = product.Name;
            toBeEditedProduct.CategoryId = product.CategoryId;
            toBeEditedProduct.ImgUrl = product.ImageUrl;

            return _productRepository.Update(toBeEditedProduct);
        }
    }
}
