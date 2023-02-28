using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.API;
using Northwind.Application.Contracts.Persistence;
using Northwind.Application.Contracts.Services;
using Northwind.Application.Services;
using Northwind.Domain.Entities;
using Northwind.Persistence.EFCore;
using Northwind.Persistence.EFCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddDbContext<NorthwindDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnectionString")));

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
	var forecast = Enumerable.Range(1, 5).Select(index =>
		new WeatherForecast
		(
			DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			Random.Shared.Next(-20, 55),
			summaries[Random.Shared.Next(summaries.Length)]
		))
		.ToArray();
	return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/products", async ([FromServices] IProductService productService) =>
	Results.Ok(await productService.GetProducts()))
.WithName("GetProducts")
.WithOpenApi(); ;

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


