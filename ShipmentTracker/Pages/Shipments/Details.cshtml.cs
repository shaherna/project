using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Data;
using ShipmentTracker.Models;

namespace ShipmentTracker.Pages.Shipments
{
    public class DetailsModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public DetailsModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Shipment Shipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shipment == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment.Include(x => x.Employee).
                Include(y => y.Customer).FirstOrDefaultAsync(m => m.ShipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }
            else 
            {
                Shipment = shipment;
            }
            return Page();
        }
    }
}
