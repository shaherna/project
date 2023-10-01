using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ShipmentTracker.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Customer Name required")]
        public string CustomerName { get; set; }
        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone Number required")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public long PhoneNumber { get; set; }
        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        public string Email { get; set; }
       // public List<Shipment>? Shipments { get; set; }
        public List<Payment>? Payments { get; set; }
    }
}
