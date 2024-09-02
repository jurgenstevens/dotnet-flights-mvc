using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

// EVENTUALLY ADD ONE OF THESE MODELS TO SEARCH BY PASSENGER

namespace MvcFlight.Models;

public class FlightAirportViewModel
{
  public List<Flight>? Flights { get; set; }
  public SelectList? Airports { get; set; }
  public string? FlightAirport { get; set; }
  public string? SearchAirport { get; set; } 
}