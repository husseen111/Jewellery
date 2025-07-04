using Microsoft.EntityFrameworkCore;

namespace JewelleryApi.Interfaces
{
    public class JewelleryService : IJewelleryService
    {
        private readonly ApplicationDbContext _context;

        public JewelleryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Jewellery>> GetAllAsync()
        {
            return await _context.Jewelleries.ToListAsync();
        }
        public async Task<Jewellery?> GetByIdAsync(int id)
        {
            return await _context.Jewelleries.FindAsync(id);
        }

        public async Task<Jewellery> CreateAsync(CreateJewelleryDto dto)
        {
            var jewellery = new Jewellery
            {
                Name = dto.name,
                Description = dto.Description,
                Material = dto.Material,
                Price = dto.Price,
                Weight = dto.Weight
            };
            await _context.Jewelleries.AddAsync(jewellery);
            await _context.SaveChangesAsync();
            return jewellery;
        }
        public async Task<Jewellery?> UpdateAsync(int id, CreateJewelleryDto dto)
        {
            var jewellery = await _context.Jewelleries.SingleOrDefaultAsync(j => j.Id == id);
            if (jewellery == null)
                return null;

            jewellery.Name = dto.name;
            jewellery.Description = dto.Description;
            jewellery.Material = dto.Material;
            jewellery.Price = dto.Price;
            jewellery.Weight = dto.Weight;

            await _context.SaveChangesAsync();
            return jewellery;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var jewellery = await _context.Jewelleries.FindAsync(id);
            if (jewellery == null)
                return false;

            _context.Jewelleries.Remove(jewellery);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
