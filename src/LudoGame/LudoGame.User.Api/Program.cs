
using LudoGame.User.Application.Calculator;
using LudoGame.User.Application.Calculator.Models;
using LudoGame.User.Application.Interfaces;
using LudoGame.User.Infrastructure.DataBase;
using LudoGame.User.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContextPool<ApplicationDbContext>(opt => opt.UseNpgsql("Server=localhost;Port=5432;Database=LudoGame;Username=postgres;Password=123456;"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICalculateService,CalculateService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapPost("/calculate", async (CalculateModel model,ICalculateService service) =>
{
    Console.WriteLine($"check -> {model}");
    //var service = new CalculateService();
    return await service.Calculate(model);
}
    );
app.Run();
