namespace SalesManagementSystem.Models.DTOs
{
    public class CreateSaleDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
