namespace JewelleryApi.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(CreateCategoryDto dto);
        Task<Category> UpdateAsync(int id, CreateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
