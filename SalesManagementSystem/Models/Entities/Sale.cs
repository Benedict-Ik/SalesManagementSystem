namespace SalesManagementSystem.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime SoldAt { get; set; }
        public string InternalReference { get; set; } = string.Empty;
    }
}
