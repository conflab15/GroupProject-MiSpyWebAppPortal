using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiSpyWebAppPortal.Data;
using MiSpyWebAppPortal.Models;

namespace MiSpyWebAppPortal.Pages.Monitor
{
    public class NewReportModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public NewReportModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<LoggedEvent> LoggedEvents { get; set; } //New paginated list model

        public async Task OnGetAsync(int? pageIndex) //Page Index value present but not always required as it's predefined within this Task
        {

            IQueryable<LoggedEvent> studentsIQ = from s in _context.LoggedEvent
                                                 where s.UserId == User.Identity.Name
                                             select s; //IQueryable Model which selects all the objects which meets the where criteria

            int pageSize = 9;
            LoggedEvents = await PaginatedList<LoggedEvent>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize); //Creating the paginated list view
        }
    }
}
