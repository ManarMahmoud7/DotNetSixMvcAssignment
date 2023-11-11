using DotNetSixMvcAssignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Domain
{
    public interface IFetchProductsService
    {
        IList<ProductDto> GetByCategoryId(int categoryId);  

        ProductDto GetById(int productId);
    }
}
