using AutoMapper;
using SalesManagementSystem.Models.DTOs;
using SalesManagementSystem.Models.Entities;
using SalesManagementSystem.Services.Interfaces;

namespace SalesManagementSystem.Services.Implementations
{
    public class SalesService_AutoMapper:ISalesService
    {
        private static readonly List<Sale> _sales = new();
        private static int _idCounter = 1;
        private readonly IMapper _mapper;

        public SalesService_AutoMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SaleDto CreateSale(CreateSaleDto dto)
        {
            // Map the incoming CreateSaleDto to a new Sale entity
            var sale = _mapper.Map<Sale>(dto);

            // Assign a unique Id using an incrementing counter
            sale.Id = _idCounter++;

            var watTimestamp = DateTime.UtcNow.AddHours(1);

            // Record the current UTC time as the sale timestamp, incrementing by a hour to represent WAT region
            sale.SoldAt = watTimestamp;

            // Generate a unique internal reference string based on the current timestamp
            sale.InternalReference = $"Sales-{watTimestamp:yyyyMMddHHmmssfff}";

            // Add the new Sale entity to the in-memory sales collection
            _sales.Add(sale);

            var saleDto = _mapper.Map<SaleDto>(sale);

            // Map the Sale entity back to a SaleDto for returning to the caller
            return saleDto;
        }

        public SaleDto GetSaleById(int id)
        {
            // Find the first Sale in the _sales collection that matches the given Id
            var sale = _sales.FirstOrDefault(x => x.Id == id);

            if (sale == null)
            {
                return null;
            }

            var result = _mapper.Map<SaleDto>(sale);

            // Map the Sale entity to a SaleDto for returning to the caller
            return result;
        }

        public List<SaleDto> GetAllSales()
        {
            // Map the entire _sales collection (List<Sale>) 
            // into a List<SaleDto> using AutoMapper

            var result = _mapper.Map<List<SaleDto>>(_sales);
            return result;
        }

        public SaleDto UpdateSale(int id, CreateSaleDto dto)
        {
            // Find the first Sale in the _sales collection that matches the given Id
            var sale = _sales.FirstOrDefault(x => x.Id == id);

            if (sale == null)
            {
                return null;
            }

            // Map the incoming CreateSaleDto onto the existing Sale entity
            // This updates the Sale's properties with values from the DTO
            _mapper.Map(dto, sale);

            // Map the updated Sale entity back to a SaleDto for returning to the caller
            var result = _mapper.Map<SaleDto>(sale);

            return result;
        }

        public string DeleteSale(int id)
        {
            // Attempt to find the sale with the given ID in the in-memory list.
            var sale = _sales.FirstOrDefault(x => x.Id == id);

            // If no sale is found, return a descriptive message.
            if (sale == null)
            {
                //return $"Sale with ID {id} not found.";
                return null;
            }

            // Remove the found sale from the in-memory list.
            _sales.Remove(sale);

            // Return a confirmation message indicating successful deletion.
            return $"Sale with ID {id} has been deleted.";
        }
    }
}
