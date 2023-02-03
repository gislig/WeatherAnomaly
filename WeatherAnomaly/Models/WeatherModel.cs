using System.ComponentModel.DataAnnotations;

namespace WeatherAnomaly.Models;

public class WeatherModel
{
    [Key]
    public int id { get; set; }
    public string country { get; set; }
    public float fx { get; set; } // fx = top wind speed
    public float f { get; set; } // f = wind speed
    public float t { get; set; } // t = air temperature
    public float p { get; set; } // p = air pressure
}