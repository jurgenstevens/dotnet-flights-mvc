using System.ComponentModel.DataAnnotations;

namespace MvcFlight.Models;

public class Flight
{
    // ADD PASSENGER PROPERTY FOR EACH FLIGHT
    public int Id { get; set; }
    public string? Airline { get; set; }
    [DataType(DataType.Date)]
    public DateTime Departs { get; set; }
    public string? Airport { get; set; }
    public int FlightNo { get; set; }
    public string? Ticket { get; set; }
}