
using Microsoft.EntityFrameworkCore;

namespace JewelleryApi.Interfaces
{
    public class CategoryService : ICategoryService 
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<Category> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
               
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();

        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(int id, CreateCategoryDto dto)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(C => C.Id == id);
            if (category == null)

                return null;

            category.Name = dto.Name;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
