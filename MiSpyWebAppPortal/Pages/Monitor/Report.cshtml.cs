using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiSpyWebAppPortal.Data;
using MiSpyWebAppPortal.Models;

namespace MiSpyWebAppPortal.Pages.Monitor
{
    public class ReportModel : PageModel
    {

        private readonly ApplicationDbContext _db; //Reading our ApplicationDbContext

        public ReportModel(ApplicationDbContext db) //Constructing the object
        {
            _db = db;
        }

        public List<LoggedEvent> Events { get; set; } //Creating a List of Event Objects to read from the Azure SQL db

        //Startup enforce Authorise for the Monitor Folder

        public void OnGet()
        {
            Events = _db.LoggedEvent.Where(Events => Events.UserId == User.Identity.Name).ToList(); //Getting the Items from the List where the Identity user matches. 
        }
    }
}
