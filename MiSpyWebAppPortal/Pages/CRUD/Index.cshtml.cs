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
    public class IndexModel : PageModel
    {
        private readonly MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext _context;

        public IndexModel(MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext context)
        {
            _context = context;
        }

        public IList<LoggedEvent> LoggedEvent { get;set; }

        public async Task OnGetAsync()
        {
            LoggedEvent = await _context.LoggedEvent.ToListAsync();
        }
    }
}
