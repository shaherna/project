using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Data;
using ShipmentTracker.Models;

namespace ShipmentTracker.Pages.Customers
{
    public class SearchModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public SearchModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;
        public bool SearchCompleted { get; set; }
        public string Query { get; set; }
        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                Customer = await _context.Customer
                           .Where(x => x.CustomerName.StartsWith(query))
                           .ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                Customer = new List<Customer>();
            }
        }
    }
}
