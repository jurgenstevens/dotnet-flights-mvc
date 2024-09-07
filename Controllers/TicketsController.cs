using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFlight.Data;
using MvcFlight.Models;

namespace dotnet_flights_mvc.Controllers
{
    public class TicketsController : Controller
    {
        private readonly MvcFlightContext _context;

        public TicketsController(MvcFlightContext context)
        {
            _context = context;
        }

        // GET: Tickets/NewTicket/5
        public async  Task<IActionResult> NewTicket(int flightId)
        {
          var flight = await _context.Flight
                .Include(f => f.Tickets)
                .FirstOrDefaultAsync(m => m.Id == flightId);

          if (flight == null)
          {
              return NotFound();
          }

          var newTicket = new Ticket
          {
              FlightId = flight.Id,
              Seat = "",
          };

          ViewBag.flightId = flight.Id;
          ViewBag.Airline = flight.Airline;
          ViewBag.FlightNo = flight.FlightNo;

          return View(newTicket);
        }

    }
}