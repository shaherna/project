using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipmentTracker.Models
{
    public class DeliveryTracking
    {
        public int DeliveryTrackingId { get; set; }
        [DisplayName("Expected Delivery Date")]
        [DataType(DataType.Date)]


        public DateTime ExpectedDeliveryDate { get; set; }
        [DisplayName("Tracking Number")]
        [Required(ErrorMessage = "Tracking Number required")]
        [StringLength(10)]

        public string TrackingNumber { get; set; }
        [DisplayName("Delivery Status")]
        [Required(ErrorMessage = "Delivery Stataus required")]


        public string DeliveryStatus { get; set; }
        [ForeignKey("ShipmentId")]
        public Shipment? Shipment { get; set; }
        [DisplayName("Shipment Number")]

        public int? ShipmentId { get; set; }
    }
}
