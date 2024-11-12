using System.ComponentModel.DataAnnotations.Schema;

namespace Bhaarat_Bazaar.models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } 
        public string PaymentStatus { get; set; }
        public int OrderId { get; set; }    
        public Order Order { get; set; }
    }
}
