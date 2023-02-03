using WeatherAnomaly.Models;
using WeatherAnomaly.ModelsDto;
using WeatherAnomaly.Repository.Interface;

namespace WeatherAnomaly.Repository.Implementation;

public class WeatherDataRepository : IWeatherDataRepository
{
    public async Task<List<WeatherModel>> GetAllWeather()
    {
        throw new NotImplementedException();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromDateToDate(DateTime fromDate, DateTime toDate)
    {
        throw new NotImplementedException();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromYearToYear(int fromYear, int toYear)
    {
        throw new NotImplementedException();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromMonthToMonth(int fromMonth, int toMonth)
    {
        throw new NotImplementedException();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromDayToDay(int fromDay, int toDay)
    {
        throw new NotImplementedException();
    }

    public async Task<List<WeatherModel>> GetAllWeatherFromHourToHour(int fromHour, int toHour)
    {
        throw new NotImplementedException();
    }

    public async Task<WeatherModel> AddWeather(WeatherDto weather)
    {
        throw new NotImplementedException();
    }
}