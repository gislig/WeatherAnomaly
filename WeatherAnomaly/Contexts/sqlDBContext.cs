using Microsoft.EntityFrameworkCore;
using WeatherAnomaly.Models;

namespace WeatherAnomaly.Contexts;

public class sqlDBContext : DbContext
{
    public sqlDBContext(DbContextOptions<sqlDBContext> options) : base(options)
    {
    }
    
    public DbSet<WeatherModel?> Weather { get; set; }

}