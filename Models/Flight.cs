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

// Dependent (child)
public class Ticket
{
    public int Id { get; set;}
    [ForeignKey("Flight")]
    public int FlightId { get; set; }
    public Flight? Flight { get; set; }
    [RegularExpression(@"[A-F][1-9]\d?", ErrorMessage = "Must be 'A1' through 'F99'.")]
    public required string Seat { get; set; } // Required foreign key property
    [DataType(DataType.Currency)]
    [Required]
    public decimal Price { get; set; }
}