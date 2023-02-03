using WeatherAnomaly.Models;
using WeatherAnomaly.ModelsDto;

namespace WeatherAnomaly.Repository.Interface;

public interface IWeatherDataRepository
{
    Task<List<WeatherModel>> GetAllWeather();
    Task<List<WeatherModel>> GetAllWeatherFromDateToDate(DateTime fromDate, DateTime toDate);
    Task<List<WeatherModel>> GetAllWeatherFromYearToYear(int fromYear, int toYear);
    Task<List<WeatherModel>> GetAllWeatherFromMonthToMonth(int fromMonth, int toMonth);
    Task<List<WeatherModel>> GetAllWeatherFromDayToDay(int fromDay, int toDay);
    Task<List<WeatherModel>> GetAllWeatherFromHourToHour(int fromHour, int toHour);
    Task<WeatherModel> AddWeather(WeatherDto weather);
    Task DeleteWeatherByCountryName(string countryName);
}