using JewelleryApi.Interfaces;
using JewelleryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JewelleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _Service;

        public CustomerController(ICustomerService service)
        {
            _Service=service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _Service.GetAllAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _Service.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();

            }
            return customer;

        }
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CreateCustomerDto dto)
        {
            var customer = new Customer { Name = dto.Name };
            await _Service.CreateAsync(dto);
           
            return Ok(customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateCustomerDto dto)
        {
            var customer = await _Service.UpdateAsync(id,dto);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Name = dto.Name;
           
            return Ok(customer);
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _Service.DeleteAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok();


        }
    }
}
