using WeatherAnomaly.Models;
using WeatherAnomaly.ModelsDto;

namespace WeatherAnomaly.Profile;

public class WeatherProfile : AutoMapper.Profile
{
    public WeatherProfile()
    {
        CreateMap<WeatherDto, WeatherModel>();
        CreateMap<WeatherModel, WeatherDto>();
    }
}