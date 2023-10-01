using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Models;

namespace ShipmentTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShipmentTracker.Models.Customer> Customer { get; set; }
        public DbSet<ShipmentTracker.Models.DeliveryTracking> DeliveryTracking { get; set; }
        public DbSet<ShipmentTracker.Models.Employee> Employee { get; set; }
        public DbSet<ShipmentTracker.Models.Payment> Payment { get; set; }
        public DbSet<ShipmentTracker.Models.Shipment> Shipment { get; set; }
    }
}