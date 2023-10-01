using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShipmentTracker.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        [DisplayName("Shipment Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date is required")]


        public DateTime ShipmentStartDate { get; set; }
        [DisplayName("Shipment Type")]
        [Required(ErrorMessage = "Shipment Type is required")]


        public string ShipmentType { get; set; }
        [DisplayName("Shipment Number")]
        [Required(ErrorMessage = "Shipment Number is required")]
        [StringLength(10)]


        public string ShipmentNumber { get; set; }
        [DisplayName("Pickup Location")]
        [Required(ErrorMessage = "Pickup Location is required")]


        public string PickupLocation { get; set; }
        [DisplayName("Destination")]
        [Required(ErrorMessage = "Destination is required")]


        public string Destination { get; set; }
        public Customer? Customer { get; set; }
        [DisplayName("Customer Name")]

        public int CustomerId { get; set; }

        public Payment? Payment { get; set; }
        [DisplayName("Transaction Number")]

        public int? PaymentId { get; set; }

        public DeliveryTracking? DeliveryTracking { get; set; }
        [DisplayName("Tracking Number")]

        public int? DeliveryTrackingId { get; set; }
        public Employee? Employee { get; set; }
        [DisplayName("Employee Name")]

        public int EmployeeId { get; set; }
    }
}
