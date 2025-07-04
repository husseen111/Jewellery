namespace JewelleryApi.Dtos
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
