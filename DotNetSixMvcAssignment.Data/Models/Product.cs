using System.ComponentModel.DataAnnotations;

namespace DotNetSixMvcAssignment.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }   

        public string? ImgUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; } = default!;
    }
}