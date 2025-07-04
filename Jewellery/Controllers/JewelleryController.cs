
using JewelleryApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JewelleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelleryController : ControllerBase
    {
        private readonly IJewelleryService _service;

        public JewelleryController(IJewelleryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jewellery>>> GetJewelleries()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Jewellery>> GetJewellery(int id)
        {
            var jewellery = await _service.GetByIdAsync(id);
            if (jewellery == null)
            {
                return NotFound();
            }
            return jewellery;
        }
        [HttpPost]
        public async Task<ActionResult<Jewellery>> CreateJewellery(CreateJewelleryDto dto )
        {
            var jewellery = new Jewellery { Name = dto.name};
            await _service.CreateAsync(dto);
           
            return Ok(jewellery);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJewellery(int id)
        {
            var jewellery = await _service.DeleteAsync(id);
            if (jewellery == null)
            {
                return NotFound();
            }
           
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(  int id, [FromBody] CreateJewelleryDto dto )
        {
            var jewellery = await _service.UpdateAsync(id, dto);
            if (jewellery == null)
            {
                return NotFound();
            }
            jewellery.Name = dto.name;
            jewellery.Price = dto.Price;
            jewellery.Description = dto.Description;
            jewellery.Weight = dto.Weight;
            jewellery.Material= dto.Material;
          
            return Ok(jewellery);
        }





    }

}
