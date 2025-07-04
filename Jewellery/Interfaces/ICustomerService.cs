namespace JewelleryApi.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer> CreateAsync(CreateCustomerDto dto);
        Task<Customer?> UpdateAsync(int id, CreateCustomerDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
