using SalesManagementSystem.Models.DTOs;
using SalesManagementSystem.Models.Entities;
using SalesManagementSystem.Services.Interfaces;

namespace SalesManagementSystem.Services.Implementations
{
    public class SalesService_Manual : ISalesService
    {
        // In-memory storage for sales records
        private static readonly List<Sale> _sales = new();

        // Counter to generate unique IDs for each sale
        private static int _idCounter = 1;

        public SaleDto CreateSale(CreateSaleDto dto)
        {
            var watTimestamp = DateTime.UtcNow.AddHours(1);

            // Create a new Sale entity from the provided DTO
            var sale = new Sale
            {
                Id = _idCounter++,
                ProductName = dto.ProductName,
                Amount = dto.Amount,
                SoldAt = watTimestamp, 
                InternalReference = $"Sales-{watTimestamp:yyyyMMddHHmmssfff}" // Unique internal reference
            };

            _sales.Add(sale); // Add sale to in-memory list
            return MapToDto(sale); // Return DTO representation

        }
        public SaleDto GetSaleById(int id)
        {
            // Try to find the sale with the given ID
            var sale = _sales.FirstOrDefault(x => x.Id == id);

            // If no sale is found, handle gracefully
            if (sale == null)
            {
                 return null;
            }

            // Map the entity to a DTO and return
            return MapToDto(sale);
        }

        public List<SaleDto> GetAllSales()
        {
            // Create a new list to hold the mapped DTOs
            var salesDtos = new List<SaleDto>();

            // Iterate through each Sale in the in-memory list
            foreach (var sale in _sales)
            {
                // Convert Sale entity to SaleDto and add to the result list
                salesDtos.Add(MapToDto(sale));
            }

            return salesDtos;
        }
        public SaleDto UpdateSale(int id, CreateSaleDto dto)
        {
            // Find the sale in the in-memory list that matches the given ID.
            var sale = _sales.FirstOrDefault(x => x.Id == id);

            if(sale == null)
            {
                return null;
            }

            // Update the sale's properties with the new values provided in the DTO.
            sale.ProductName = dto.ProductName;
            sale.Amount = dto.Amount;

            // Convert the updated Sale entity into a SaleDto and return it.
            return MapToDto(sale);
        }
        public string DeleteSale(int id)
        {
            // Attempt to find the sale with the given ID in the in-memory list.
            var sale = _sales.FirstOrDefault(x => x.Id == id);

            // If no sale is found, return a descriptive message.
            if (sale == null)
            {
                //return $"Sale with ID '{id}' not found.";
                return null;
            }

            // Remove the found sale from the in-memory list.
            _sales.Remove(sale);

            // Return a confirmation message indicating successful deletion.
            return $"Sale with ID '{id}' has been deleted.";
        }

        #region Helpers
        // Manually map Sale entity to SaleDto
        private static SaleDto MapToDto(Sale sale)
        {
            return new SaleDto
            {
                Id = sale.Id,
                ProductName = sale.ProductName,
                Amount = sale.Amount,
                SoldAt = sale.SoldAt.ToString("ddd, MMM dd, hh:mm:ss tt")
            };
        }
        #endregion
    }
}
