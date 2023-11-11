using DotNetSixMvcAssignment.Data;
using DotNetSixMvcAssignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSixMvcAssignment.Domain.Implementation
{
    public class FetchCategoriesService : IFetchCategoriesService
    {
        private readonly ICategoryRepository _categoryRepository;

        public FetchCategoriesService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IList<CategoryDto> Execute()
        {
            return _categoryRepository.GetAll().Select(
                c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .OrderBy(c => c.Name).ToList();
        }
    }
}
