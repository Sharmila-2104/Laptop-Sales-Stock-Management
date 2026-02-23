namespace StockManagementSystem.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public int LaptopId { get; set; }
        public int Qty { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public Laptop Laptop { get; set; }
    }
}
