using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiSpyWebAppPortal.Data;
using MiSpyWebAppPortal.Models;

namespace MiSpyWebAppPortal.Pages.CRUD
{
    public class CreateModel : PageModel
    {
        private readonly MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext _context;

        public CreateModel(MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoggedEvent LoggedEvent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LoggedEvent.Add(LoggedEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
