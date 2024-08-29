using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Flight
{
    public int Id { get; set; }
    public string? Airline { get; set; }
    [DataType(DataType.Date)]
    public DateTime Departs { get; set; }
    public string? Airport { get; set; }
    public int FlightNo { get; set; }
}