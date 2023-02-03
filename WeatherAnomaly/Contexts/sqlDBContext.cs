using Microsoft.EntityFrameworkCore;
using WeatherAnomaly.Models;

namespace WeatherAnomaly.Contexts;

public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }
    
    public DbSet<WeatherModel> Weather { get; set; }

}