using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcFlight.Data;
using MvcFlight.Models;
using System;
using System.Linq;

namespace MvcMFlight.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcFlightContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcFlightContext>>()))
        {
            // Look for any movies.
            if (context.Flight.Any())
            {
                return;   // DB has been seeded
            }
            context.Flight.AddRange(
                new Flight
                {
                    Id = 1,
                    Airline = "United Airlines",
                    Departs = DateTime.Parse("2024-09-10 10:00:00"),
                    Airport = "ORD",
                    FlightNo = 101,
                    Tickets = 
                    [
                        new Ticket { Seat = "A1", Price = 600.00M },
                        new Ticket { Seat = "F10", Price = 100.00M }
                    ]
                },
                new Flight
                {
                    Id = 2,
                    Airline = "American Airlines",
                    Departs = DateTime.Parse("2024-09-11 12:30:00"),
                    Airport = "LAX",
                    FlightNo = 202,
                    Tickets = 
                    [
                        new Ticket { Seat = "B1", Price = 500.00M },
                        new Ticket { Seat = "F15", Price = 100.00M }
                    ]
                },
                new Flight
                {
                    Id = 3,
                    Airline = "Delta Airlines",
                    Departs = DateTime.Parse("2024-09-12 14:45:00"),
                    Airport = "MDW",
                    FlightNo = 303,
                    Tickets = 
                    [
                        new Ticket { Seat = "A1", Price = 600.00M },
                        new Ticket { Seat = "F10", Price = 100.00M }
                    ]
                },
                new Flight
                {
                    Id = 4,
                    Airline = "Southwest Airlines",
                    Departs = DateTime.Parse("2024-09-13 16:15:00"),
                    Airport = "DEN",
                    FlightNo = 404,
                    Tickets = 
                    [
                        new Ticket { Seat = "A1", Price = 600.00M },
                        new Ticket { Seat = "F10", Price = 100.00M }
                    ]
                }
            );
            context.SaveChanges();
        }
    }
}