using Microsoft.EntityFrameworkCore;
using WeatherAnomaly.Contexts;
using WeatherAnomaly.Repository.Implementation;
using WeatherAnomaly.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IWeatherDataRepository, WeatherDataRepository>();

// Add SQL service
var connDB = builder.Configuration.GetConnectionString("WeatherAnomaly");

// Add Database Service
builder.Services.AddDbContext<sqlDBContext>(options =>
    options.UseSqlServer(connDB));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
