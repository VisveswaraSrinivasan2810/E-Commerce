using System.ComponentModel.DataAnnotations;

namespace Bhaarat_Bazaar.models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
