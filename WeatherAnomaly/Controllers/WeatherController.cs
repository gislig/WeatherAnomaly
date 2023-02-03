using Microsoft.AspNetCore.Mvc;
using WeatherAnomaly.Models;
using WeatherAnomaly.ModelsDto;
using WeatherAnomaly.Repository.Interface;

namespace WeatherAnomaly.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherDataRepository _weatherDataRepository;
    
    public WeatherController(IWeatherDataRepository weatherDataRepository)
    {
        _weatherDataRepository = weatherDataRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeather()
    {
        return Ok(_weatherDataRepository.GetAllWeather());
    }
    
    [HttpGet("date/{fromDate}/{toDate}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromDateToDate(DateTime fromDate, DateTime toDate)
    {
        return Ok(_weatherDataRepository.GetAllWeatherFromDateToDate(fromDate, toDate));
    }
    
    [HttpGet("year/{fromYear}/{toYear}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromYearToYear(int fromYear, int toYear)
    {
        return Ok(_weatherDataRepository.GetAllWeatherFromYearToYear(fromYear, toYear));
    }
    
    [HttpGet("month/{fromMonth}/{toMonth}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromMonthToMonth(int fromMonth, int toMonth)
    {
        return Ok(_weatherDataRepository.GetAllWeatherFromMonthToMonth(fromMonth, toMonth));
    }
    
    [HttpGet("day/{fromDay}/{toDay}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromDayToDay(int fromDay, int toDay)
    {
        return Ok(_weatherDataRepository.GetAllWeatherFromDayToDay(fromDay, toDay));
    }
    
    [HttpGet("hour/{fromHour}/{toHour}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromHourToHour(int fromHour, int toHour)
    {
        return Ok(_weatherDataRepository.GetAllWeatherFromHourToHour(fromHour, toHour));
    }
    
    [HttpPost]
    public async Task<ActionResult<WeatherModel>> AddWeather(WeatherDto weather)
    {
        return Ok(_weatherDataRepository.AddWeather(weather));
    }

}