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
    public class DeleteModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public DeleteModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DeliveryTracking DeliveryTracking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeliveryTracking == null)
            {
                return NotFound();
            }

            var deliverytracking = await _context.DeliveryTracking.Include(x => x.Shipment).FirstOrDefaultAsync(m => m.DeliveryTrackingId == id);

            if (deliverytracking == null)
            {
                return NotFound();
            }
            else 
            {
                DeliveryTracking = deliverytracking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DeliveryTracking == null)
            {
                return NotFound();
            }
            var deliverytracking = await _context.DeliveryTracking.FindAsync(id);

            if (deliverytracking != null)
            {
                DeliveryTracking = deliverytracking;
                _context.DeliveryTracking.Remove(DeliveryTracking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
