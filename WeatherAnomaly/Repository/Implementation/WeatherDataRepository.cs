using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeatherAnomaly.Contexts;
using WeatherAnomaly.Models;
using WeatherAnomaly.ModelsDto;
using WeatherAnomaly.Repository.Interface;

namespace WeatherAnomaly.Repository.Implementation;

public class WeatherDataRepository : IWeatherDataRepository
{
    // Initiate Automapper
    private readonly IMapper _mapper;
    private readonly SqlDbContext _context;
    
    public WeatherDataRepository(SqlDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<WeatherModel>> GetAllWeather()
    {
        return await _context.Weather.ToListAsync();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromDateToDate(DateTime fromDate, DateTime toDate)
    {
        return await _context.Weather.Where(date => date.checkTime >= fromDate && date.checkTime <= toDate).ToListAsync();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromYearToYear(int fromYear, int toYear)
    {
        DateTime fromYearDate = new DateTime(fromYear, 1, 1);
        DateTime toYearDate = new DateTime(toYear, 12, 31);
        
        return await _context.Weather.Where(date => date.checkTime >= fromYearDate && date.checkTime <= toYearDate).ToListAsync();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromMonthToMonth(int fromMonth, int toMonth)
    {
        // Get the first day of the month in the fromMonth and the last day of the month in the toMonth
        DateTime fromMonthDate = new DateTime(DateTime.Now.Year, fromMonth, 1);
        DateTime toMonthDate = new DateTime(DateTime.Now.Year, toMonth, DateTime.DaysInMonth(DateTime.Now.Year, toMonth));
        
        return await _context.Weather.Where(date => date.checkTime >= fromMonthDate && date.checkTime <= toMonthDate).ToListAsync();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromDayToDay(int fromDay, int toDay)
    {
        // Get the first hour of the day in the fromDay and the last hour of the day in the toDay
        DateTime fromDayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, fromDay, 0, 0, 0);
        DateTime toDayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, toDay, 23, 59, 59);
        
        return await _context.Weather.Where(date => date.checkTime >= fromDayDate && date.checkTime <= toDayDate).ToListAsync();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromHourToHour(int fromHour, int toHour)
    {
        // Get the first minute of the hour in the fromHour and the last minute of the hour in the toHour
        DateTime fromHourDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, fromHour, 0, 0);
        DateTime toHourDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, toHour, 59, 59);
        
        return await _context.Weather.Where(date => date.checkTime >= fromHourDate && date.checkTime <= toHourDate).ToListAsync();
    }

    public async Task<WeatherModel> AddWeather(WeatherDto weather)
    {
        // Check if the WeatherModel object already exists in the database, by checking country, t, fx, f and p and also the time
        WeatherModel weatherExists = await _context.Weather.FirstOrDefaultAsync(
            w => 
                w.country == weather.country && 
                w.t == weather.t && 
                w.fx == weather.fx && 
                w.f == weather.f && 
                w.p == weather.p && 
                w.checkTime == weather.checkTime);
        
        // If the WeatherModel object already exists in the database, return empty WeatherModel object
        if (weatherExists != null)
            return new WeatherModel();
        
        // Create a new WeatherModel object and add the data from the WeatherDto object
        // Use Automapper to map the data from the WeatherDto object to the WeatherModel object
        WeatherModel newWeather = new WeatherModel();
        newWeather.country = weather.country;
        newWeather.t = (float) weather.t;
        newWeather.fx = (float) weather.fx;
        newWeather.f = (float) weather.f;
        newWeather.p = (float) weather.p;
        
        // Add the new WeatherModel object to the database
        await _context.Weather.AddAsync(newWeather);
        await _context.SaveChangesAsync();
        
        return newWeather;
    }

    public async Task DeleteWeatherByCountryName(string countryName)
    {
        // Find all the WeatherModel objects with the countryName
        List<WeatherModel> weatherToDelete = await _context.Weather.Where(country => country.country == countryName).ToListAsync();
        
        // Remove all the WeatherModel objects with the countryName
        _context.Weather.RemoveRange(weatherToDelete);
        
        // Save the changes to the database
        await _context.SaveChangesAsync();
    }
}