using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$")]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int StockQty { get; set; }

        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
