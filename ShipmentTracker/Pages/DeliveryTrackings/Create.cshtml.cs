using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShipmentTracker.Data;
using ShipmentTracker.Models;

namespace ShipmentTracker.Pages.DeliveryTrackings
{
    public class CreateModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public CreateModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ShipmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentNumber");
            return Page();
        }

        [BindProperty]
        public DeliveryTracking DeliveryTracking { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeliveryTracking.Add(DeliveryTracking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
