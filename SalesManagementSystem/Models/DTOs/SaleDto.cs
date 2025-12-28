namespace SalesManagementSystem.Models.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string SoldAt { get; set; } = string.Empty;
    }
}
