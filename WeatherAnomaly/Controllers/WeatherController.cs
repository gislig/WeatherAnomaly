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
        return Ok(await _weatherDataRepository.GetAllWeather());
    }
    
    [HttpGet("date/{fromDate}/{toDate}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromDateToDate(DateTime fromDate, DateTime toDate)
    {
        return Ok(await _weatherDataRepository.GetAllWeatherFromDateToDate(fromDate, toDate));
    }
    
    [HttpGet("year/{fromYear}/{toYear}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromYearToYear(int fromYear, int toYear)
    {
        return Ok(await _weatherDataRepository.GetAllWeatherFromYearToYear(fromYear, toYear));
    }
    
    [HttpGet("month/{fromMonth}/{toMonth}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromMonthToMonth(int fromMonth, int toMonth)
    {
        return Ok(await _weatherDataRepository.GetAllWeatherFromMonthToMonth(fromMonth, toMonth));
    }
    
    [HttpGet("day/{fromDay}/{toDay}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromDayToDay(int fromDay, int toDay)
    {
        return Ok(await _weatherDataRepository.GetAllWeatherFromDayToDay(fromDay, toDay));
    }
    
    [HttpGet("hour/{fromHour}/{toHour}")]
    public async Task<ActionResult<List<WeatherModel>>> GetAllWeatherFromHourToHour(int fromHour, int toHour)
    {
        return Ok(await _weatherDataRepository.GetAllWeatherFromHourToHour(fromHour, toHour));
    }
    
    [HttpPost]
    public async Task<ActionResult<WeatherModel>> AddWeather(WeatherDto weather)
    {
        try{
            var result = await _weatherDataRepository.AddWeather(weather);
            if (result == null)
                return Conflict("Duplicate data exists");
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete("{countryName}")]
    public async Task<ActionResult> DeleteWeather(string countryName)
    {
        try{
            await _weatherDataRepository.DeleteWeatherByCountryName(countryName);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

}