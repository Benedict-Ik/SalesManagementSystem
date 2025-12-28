using AutoMapper;
using SalesManagementSystem.Models.DTOs;
using SalesManagementSystem.Models.Entities;

namespace SalesManagementSystem.Mapping
{
    public class SaleMappingProfile:Profile
    {
        public SaleMappingProfile()
        {
            CreateMap<Sale, SaleDto>()
                // Map the SoldAt property from DateTime to formatted string
                .ForMember(dest => dest.SoldAt,
               opt => opt.MapFrom(src => src.SoldAt.ToString("ddd, MMM dd, hh:mm:ss tt")));
            CreateMap<CreateSaleDto, Sale>();
        }
    }
}
