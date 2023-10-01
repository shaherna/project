using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ShipmentTracker.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;
        public StatisticsModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public int TotalShipments { get; set; }
        public int TotalDeliveryTrackings { get; set; }
        public int TotalCustomers { get; set; }



        public async Task OnGetAsync()
        {
            TotalShipments = await _context.Shipment.CountAsync();
            TotalDeliveryTrackings = await _context.DeliveryTracking.CountAsync();
            TotalCustomers = await _context.Customer.CountAsync();
        }
    }

    //public class InsightsTrendsModel : PageModel
    //{
    //    public void OnGet()
    //    {
    //    }
    //}
}
