using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipmentTracker.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        [DisplayName("Payment Transaction Number")]
        [Required(ErrorMessage = "Transaction Number required")]


        public long TransactionNumber { get; set; }
        [DisplayName("Charges")]
        [Range(1, 10000)]



        public decimal Amount { get; set; }
        [DisplayName("Payment Date")]
        [DataType(DataType.Date)]
    
        public DateTime PaymentDate { get; set; }
        [DisplayName("Payment Mode")]
        

        public string PaymentMode { get; set; }
        public Customer? Customer { get; set; }
        [DisplayName("Customer Name")]

        public int CustomerId { get; set; }
        [ForeignKey("ShipmentId")]
        public Shipment? Shipment { get; set; }
        [DisplayName("Shipment Number")]

        public int? ShipmentId { get; set; }
    }
}
