using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFlight.Data;
using MvcFlight.Models;

namespace dotnet_flights_mvc.Controllers
{
    public class FlightsController : Controller
    {
        private readonly MvcFlightContext _context;

        public FlightsController(MvcFlightContext context)
        {
            _context = context;
        }

        // GET: Flights
        // to search by passenger in the future pass a flightPassenger string
        public async  Task<IActionResult> Index(string flightAirport, string searchString)
        {
            if(_context.Flight == null)
            {
                return Problem("Entity set'MvcFlight.Context.Flight' is null.");
            }
            // Use LINQ to get list of airports
            IQueryable<string> airportQuery = from m in _context.Flight
                                                orderby m.Airport
                                                select m.Airport;
            var flights = from m in _context.Flight
                            .Include(f => f.Tickets)
                            select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                flights = flights.Where(s => s.Airline!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(flightAirport))
            {
                flights = flights.Where(x => x.Airport == flightAirport);
            }

            var flightAirportVM = new FlightAirportViewModel
            {
                Airports = new SelectList(await airportQuery.Distinct().ToListAsync()),
                Flights = await flights.ToListAsync()
            };

            return View(flightAirportVM);
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Airline,Departs,Airport,FlightNo,Ticket")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Airline,Departs,Airport,FlightNo,Ticket")] Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            if (flight != null)
            {
                _context.Flight.Remove(flight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}
