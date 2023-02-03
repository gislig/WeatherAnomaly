using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WeatherAnomaly.Contexts;
using WeatherAnomaly.Repository.Implementation;
using WeatherAnomaly.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();

// Add SQL service
// Get environment variable for ConnDB
string connDB = Environment.GetEnvironmentVariable("WeatherAnomaly");
if (string.IsNullOrEmpty(connDB))
{
    connDB = builder.Configuration.GetConnectionString("WeatherAnomaly");
}

// Add Database Service
builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(connDB));

// Add Automapper service
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
