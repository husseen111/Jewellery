using System.ComponentModel.DataAnnotations;

namespace JewelleryApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }   
    }
}
