using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiSpyWebAppPortal.Models;

namespace MiSpyWebAppPortal.Data
{
    public class MiSpyWebAppPortalContext : DbContext
    {
        public MiSpyWebAppPortalContext (DbContextOptions<MiSpyWebAppPortalContext> options)
            : base(options)
        {
        }

        public DbSet<MiSpyWebAppPortal.Models.LoggedEvent> LoggedEvent { get; set; }
    }
}
