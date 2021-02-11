using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MiSpyWebAppPortal.Models;
//using Pdf Functions
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;

namespace MiSpyWebAppPortal.Pages.Monitor
{
    public class EventModel : PageModel
    {
        private readonly MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EventModel(MiSpyWebAppPortal.Data.MiSpyWebAppPortalContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        

        public LoggedEvent LoggedEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoggedEvent = await _context.LoggedEvent.FirstOrDefaultAsync(mbox => mbox.Id == id);

            if (LoggedEvent == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Custom Function to Export to a PDF
        public IActionResult OnPostCreateDocument(LoggedEvent loggedEvent)
        {
            LoggedEvent EventFromDB = _context.LoggedEvent.Find(loggedEvent.Id);

            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString($"MiSpy Keylogger \nEvent Report \nTime: {EventFromDB.Time} \nUser ID: {EventFromDB.UserId} \n Logged Entry: {EventFromDB.Event}", font, PdfBrushes.Black, new PointF(0, 0));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Output.pdf";
            return fileStreamResult;
        }
    }
}
