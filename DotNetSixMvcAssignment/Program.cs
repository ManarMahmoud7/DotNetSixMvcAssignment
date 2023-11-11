using Microsoft.EntityFrameworkCore;
using DotNetSixMvcAssignment.Data;
using Microsoft.AspNetCore.Identity;
using DotNetSixMvcAssignment.Data.Implementation;
using DotNetSixMvcAssignment.Domain;
using DotNetSixMvcAssignment.Domain.Implementation;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProductsDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ProductsDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAddProductService, AddProductService>();
builder.Services.AddTransient<IUpdateProductService, UpdateProductService>();
builder.Services.AddTransient<IDeleteProductService, DeleteProductService>();
builder.Services.AddTransient<IFetchCategoriesService, FetchCategoriesService>();
builder.Services.AddTransient<IFetchProductsService, FetchProductsService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<ProductsDbContext>(options => {
    options.UseSqlServer(connectionString);
});


builder.Services.AddServerSideBlazor();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ProductsDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapBlazorHub();

app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

app.Run();
