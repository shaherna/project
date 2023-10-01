using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShipmentTracker.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Name required")]

        public string EmployeeName { get; set; }
        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]

        public string Email { get; set; }
        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Contact Number is required")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Contact Number.")]

        public long Contact { get; set; }
        //public List<Shipment>? Shipments { get; set; }
    }
}
