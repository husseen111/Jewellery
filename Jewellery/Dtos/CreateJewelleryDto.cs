namespace JewelleryApi.Dtos
{
    public class CreateJewelleryDto
    {
        [MaxLength(100)]
        public string name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
        public decimal Weight { get; set; }
    }
}
