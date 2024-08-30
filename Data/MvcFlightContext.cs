using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFlight.Models;

namespace MvcFlight.Data
{
    public class MvcFlightContext : DbContext
    {
        public MvcFlightContext (DbContextOptions<MvcFlightContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFlight.Models.Flight> Flight { get; set; } = default!;
    }
}
