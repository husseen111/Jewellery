
using JewelleryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelleryApi.Interfaces
{
    public class CustomerService : ICustomerService

    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<Customer> CreateAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
           return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer?> UpdateAsync(int id, CreateCustomerDto dto)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(C => C.Id == id);
            if (customer == null)
            
                return null;
            
            customer.Name = dto.Name;
           await _context.SaveChangesAsync();
            return customer;
        }
    }
}
