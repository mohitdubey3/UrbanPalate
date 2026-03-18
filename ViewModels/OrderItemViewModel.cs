using System.ComponentModel.DataAnnotations;

namespace UrbanPalate.Models
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
