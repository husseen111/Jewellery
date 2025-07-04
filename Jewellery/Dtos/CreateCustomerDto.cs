namespace JewelleryApi.Dtos
{
    public class CreateCustomerDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
