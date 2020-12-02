using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiSpyWebAppPortal.Data;
using MiSpyWebAppPortal.Models;

namespace MiSpyWebAppPortal.Pages.CRUD
{
    public class EditModel : PageModel
    {
        private readonly MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext _context;

        public EditModel(MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LoggedEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoggedEventExists(LoggedEvent.Id))
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

        private bool LoggedEventExists(int id)
        {
            return _context.LoggedEvent.Any(e => e.Id == id);
        }
    }
}
