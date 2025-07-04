namespace JewelleryApi.Interfaces
{
    public interface IJewelleryService
    {
        Task<List<Jewellery>> GetAllAsync();
        Task<Jewellery?> GetByIdAsync(int id);
        Task<Jewellery> CreateAsync(CreateJewelleryDto dto);
        Task<Jewellery?> UpdateAsync(int id, CreateJewelleryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
