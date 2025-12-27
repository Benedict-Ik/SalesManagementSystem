using AutoMapper;
using SalesManagementSystem.Models.DTOs;
using SalesManagementSystem.Models.Entities;

namespace SalesManagementSystem.Mapping
{
    public class SaleMappingProfile:Profile
    {
        public SaleMappingProfile()
        {
            CreateMap<Sale, SaleDto>();
            CreateMap<CreateSaleDto, Sale>();
        }
    }
}
