namespace WeatherAnomaly.ModelsDto;

public class WeatherDto
{
    public string country { get; set; }
    public float fx { get; set; } // fx = top wind speed
    public float f { get; set; } // f = wind speed
    public float t { get; set; } // t = air temperature
    public float p { get; set; } // p = air pressure
    public DateTime checkTime { get; set; }
}