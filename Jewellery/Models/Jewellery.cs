using System.ComponentModel.DataAnnotations;

namespace JewelleryApi.Models
{
    public class Jewellery
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } 
        public decimal Price { get; set; }
        public string Material { get; set; } 
        public decimal Weight { get; set; }

    }
}
