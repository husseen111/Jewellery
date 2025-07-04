using JewelleryApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JewelleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _Service;

        public CategoryController(ICategoryService service)
        {
            _Service=service;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var Result = await _Service.GetAllAsync();
            return Ok(Result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategories(int id)
        {
            var category = await _Service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();

            }
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryDto dto)
        {
            var category = new Category { Name = dto.Name };
            await _Service.CreateAsync(dto);
          
            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateCategoryDto dto)
        {
            var category = await _Service.UpdateAsync(id,dto);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = dto.Name;
           
            return Ok(category);
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var category = await _Service.DeleteAsync (id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}     
