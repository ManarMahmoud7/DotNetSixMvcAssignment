using DotNetSixMvcAssignment.Data.Models;
using DotNetSixMvcAssignment.Domain;
using DotNetSixMvcAssignment.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DotNetSixMvcAssignment.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IAddProductService _addProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IFetchCategoriesService _fetchCategoriesService;
        private readonly IFetchProductsService _fetchProductsService;
        public static IList<CategoryDto> Categories;
        private IWebHostEnvironment _webEnv;

        public ProductController(
            IAddProductService addProductService,
            IUpdateProductService updateProductService,
            IDeleteProductService deleteProductService,
            IFetchCategoriesService fetchCategoriesService,
            IFetchProductsService fetchProductsService,
            IWebHostEnvironment webEnv
           )
        {
            _addProductService = addProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
            _fetchCategoriesService = fetchCategoriesService;
            _fetchProductsService = fetchProductsService;
            _webEnv = webEnv;
        }

        public IActionResult AddProduct()
        {
            ViewBag.Categories = Categories != null && Categories.Count > 0 ? Categories : _fetchCategoriesService.Execute();

            ViewBag.defaultCategoryId = Categories?.FirstOrDefault()?.Id ?? 0;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                if (product.Upload is not null)
                {
                    product.ImageUrl = product.Upload.FileName;

                    var file = Path.Combine(_webEnv.ContentRootPath,
                        "wwwroot/images/products", product.Upload.FileName);

                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await product.Upload.CopyToAsync(fileStream);
                    }
                }

                _addProductService.Execute(product);

                return RedirectToAction("products", "app");
            }
            ViewBag.Categories = Categories;

            ViewBag.defaultCategoryId = product.CategoryId > 0 ? product.CategoryId : Categories.First().Id;

            return View();
        }


        public IActionResult EditProduct([FromRoute] int id)
        {
            ViewBag.Categories = Categories != null && Categories.Count > 0 ? Categories : _fetchCategoriesService.Execute();
            var editedProduct = _fetchProductsService.GetById(id);
            if (editedProduct != null)
            {
                ViewBag.defaultCategoryId = editedProduct.CategoryId;
            }
            return View(editedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                if (product.Upload is not null)
                {
                    product.ImageUrl = product.Upload.FileName;

                    var file = Path.Combine(_webEnv.ContentRootPath,
                        "wwwroot/images/products", product.Upload.FileName);

                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await product.Upload.CopyToAsync(fileStream);
                    }
                }

                _updateProductService.Execute(product);

                return RedirectToAction("products", "app");
            }
            ViewBag.Categories = Categories;

            ViewBag.defaultCategoryId = product.CategoryId > 0 ? product.CategoryId : Categories.First().Id;

            return View();
        }

        public IActionResult DeleteProduct([FromRoute] int id)
        {
            _deleteProductService.Execute(id);
            return RedirectToAction("products", "app");
        }

        [AllowAnonymous]
        public IActionResult ProductDetails(int id)
        {
            ViewBag.Categories = Categories != null && Categories.Count > 0 ? Categories : _fetchCategoriesService.Execute();
            var product = _fetchProductsService.GetById(id);
            if (product != null)
            {
                ViewBag.defaultCategoryId = product.CategoryId;
            }
            return View(product);
        }
    }
}
