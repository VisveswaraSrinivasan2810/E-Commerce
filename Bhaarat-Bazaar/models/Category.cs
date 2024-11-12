using System.ComponentModel.DataAnnotations;

namespace Bhaarat_Bazaar.models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
