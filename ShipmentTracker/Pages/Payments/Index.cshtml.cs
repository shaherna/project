using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Data;
using ShipmentTracker.Models;

namespace ShipmentTracker.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public IndexModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Payment != null)
            {
                Payment = await _context.Payment
                .Include(p => p.Customer)
                .Include(p => p.Shipment).ToListAsync();
            }
        }
    }
}
