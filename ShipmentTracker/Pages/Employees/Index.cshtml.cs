using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Data;
using ShipmentTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace ShipmentTracker.Pages.Employees
{
    //[Authorize(Roles = "employee")]
    public class IndexModel : PageModel
    {
        private readonly ShipmentTracker.Data.ApplicationDbContext _context;

        public IndexModel(ShipmentTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employee != null)
            {
                Employee = await _context.Employee.ToListAsync();
            }
        }
    }
}
