using DotNetSixMvcAssignment.Data;
using DotNetSixMvcAssignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Domain.Implementation
{
    public class FetchProductsService : IFetchProductsService
    {
        private readonly IProductRepository _productsRepository;

        public FetchProductsService(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public IList<ProductDto> GetByCategoryId(int categoryId)
        {
            return _productsRepository.GetAll()
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImgUrl,
                    Quantity = p.Quantity,
                    Price = p.Price,
                })
                .OrderBy(p=>p.Name)
                .ToList();
        }

        public ProductDto GetById(int productId)
        {
            //To Use AutoMapper
            var product = _productsRepository.GetByProductId(productId);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price= product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                ImageUrl= product.ImgUrl
            };
        }
    }
}
