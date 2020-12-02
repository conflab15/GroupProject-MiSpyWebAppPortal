using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiSpyWebAppPortal.Data;
using MiSpyWebAppPortal.Models;

namespace MiSpyWebAppPortal.Pages.CRUD
{
    public class DetailsModel : PageModel
    {
        private readonly MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext _context;

        public DetailsModel(MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext context)
        {
            _context = context;
        }

        public LoggedEvent LoggedEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoggedEvent = await _context.LoggedEvent.FirstOrDefaultAsync(m => m.Id == id);

            if (LoggedEvent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
