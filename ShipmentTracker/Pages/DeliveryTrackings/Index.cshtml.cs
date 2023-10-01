using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Data;
using ShipmentTracker.Models;

namespace ShipmentTracker.Pages.DeliveryTrackings
{
    public class IndexModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public IndexModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DeliveryTracking> DeliveryTracking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DeliveryTracking != null)
            {
                DeliveryTracking = await _context.DeliveryTracking
                .Include(d => d.Shipment).ToListAsync();
            }
        }
    }
}
