using System.ComponentModel.DataAnnotations;

namespace PassingTrips.Models;

public class Coordinate
{
    public int Id { get; set; }
    [Range(-90, 90)]
    public float Width { get; set; }
    [Range(0, 180)]
    public float Longitude { get; set; }
}