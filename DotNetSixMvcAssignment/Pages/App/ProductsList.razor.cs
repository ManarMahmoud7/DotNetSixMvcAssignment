using DotNetSixMvcAssignment.Domain;
using DotNetSixMvcAssignment.Domain.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System;
using System.ComponentModel;

namespace DotNetSixMvcAssignment.Pages.App
{
    public partial class ProductsList
    {
        private IList<CategoryDto> _categories;

        public IList<CategoryDto> Categories
        {
            get
            {
                if (_categories == null || _categories.Count == 0)
                {
                    _categories = GetCategories();
                    LoadDefaultCategory();
                }

                return _categories;
            }
        }

        public int DefaultCategoryId { get; set; }

        public IList<ProductDto> FilteredProducts { get; set; } = new List<ProductDto>();

        [Inject]
        public IFetchCategoriesService? FetchCategoriesService { get; set; }

        [Inject]
        public IFetchProductsService? FetchProductsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IHttpContextAccessor context {get;set;}

        private IList<CategoryDto> GetCategories()
        {
            if (FetchCategoriesService is null) return new List<CategoryDto>();

            return FetchCategoriesService.Execute();
        }

        private void FilterProductsByCategory(ChangeEventArgs e)
        {
            FilteredProducts.Clear();

            int.TryParse(e.Value?.ToString(), out int selectedCategory);

            if (FetchProductsService is not null & selectedCategory > 0)
                FilteredProducts = FetchProductsService.GetByCategoryId(selectedCategory);
        }

        private void LoadDefaultCategory()
        {
            if (FetchProductsService is not null && Categories != null && Categories.Count > 0)
                FilteredProducts = FetchProductsService.GetByCategoryId(Categories.First().Id);
        }

        private void NavigateToProductController(string action,int productId)
        {
            NavigationManager.NavigateTo($"Product/{action}/{productId}", true);
        }
    }
}
