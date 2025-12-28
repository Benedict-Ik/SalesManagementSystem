using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models.DTOs;
using SalesManagementSystem.Services.Interfaces;

namespace SalesManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost("CreateSales")]
        public IActionResult Create(CreateSaleDto dto)
        {
            var result = _salesService.CreateSale(dto);
            return Ok(result);
        }

        [HttpGet("GetSalesById/{id}")]
        public IActionResult Get(int id)
        {
            var result = _salesService.GetSaleById(id);
            return Ok(result);
        }

        [HttpGet("GetAllSales")]
        public IActionResult GetAll()
        {
            var result = _salesService.GetAllSales();
            return Ok(result);
        }

        [HttpPut("UpdateSalesById/{id}")]
        public IActionResult Update(int id, CreateSaleDto dto)
        {
            var result = _salesService.UpdateSale(id, dto);
            return Ok(result);
        }

        [HttpDelete("DeleteSalesById/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _salesService.DeleteSale(id);

            return Ok(result);
        }
    }
}
