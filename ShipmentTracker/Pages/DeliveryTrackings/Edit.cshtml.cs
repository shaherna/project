using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Data;
using ShipmentTracker.Models;

namespace ShipmentTracker.Pages.DeliveryTrackings
{
    public class EditModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public EditModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeliveryTracking DeliveryTracking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeliveryTracking == null)
            {
                return NotFound();
            }

            var deliverytracking =  await _context.DeliveryTracking.FirstOrDefaultAsync(m => m.DeliveryTrackingId == id);
            if (deliverytracking == null)
            {
                return NotFound();
            }
            DeliveryTracking = deliverytracking;
           ViewData["ShipmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentNumber");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeliveryTracking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryTrackingExists(DeliveryTracking.DeliveryTrackingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeliveryTrackingExists(int id)
        {
          return _context.DeliveryTracking.Any(e => e.DeliveryTrackingId == id);
        }
    }
}
