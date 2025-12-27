using SalesManagementSystem.Models.DTOs;

namespace SalesManagementSystem.Services.Interfaces
{
    public interface ISalesService
    {
        SaleDto CreateSale(CreateSaleDto dto);
        SaleDto GetSaleById(int id);
        List<SaleDto> GetAllSales();
        SaleDto UpdateSale(int id, CreateSaleDto dto);
        string DeleteSale(int id);
    }
}
