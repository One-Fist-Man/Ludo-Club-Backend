
using LudoGame.User.Application.Calculator;
using LudoGame.User.Application.Calculator.Models;
using LudoGame.User.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContextPool<ApplicationDbContext>(opt => opt.UseNpgsql("Server=192.168.68.92;Port=5011;Database=LudoGame.User;User Id=postgres; Password=123456;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapPost("/calculate", (CalculateModel model) =>
{
    Console.WriteLine("chekc->", model.Value1);
    var service = new CalculateService();
    return service.Calculate(model);
}
    );
app.Run();
