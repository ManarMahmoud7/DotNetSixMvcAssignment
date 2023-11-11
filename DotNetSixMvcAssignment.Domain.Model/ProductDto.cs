using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetSixMvcAssignment.Domain.Model
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }   

        public IFormFile? Upload { get; set; }

        public string? ImageUrl { get; set; }

    }
}