using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFlight.Models;

// Principal (parent)
public class Flight
{
    // ADD PASSENGER PROPERTY FOR EACH FLIGHT
    public int Id { get; set; }
    public string? Airline { get; set; }
    [DataType(DataType.Date)]
    public DateTime Departs { get; set; }
    public string? Airport { get; set; }
    public int FlightNo { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); // Collection navigation containing dependents
}
