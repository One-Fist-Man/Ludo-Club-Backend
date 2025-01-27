
using LudoGame.User.Application.Calculator;
using LudoGame.User.Application.Calculator.Models;
using LudoGame.User.Application.Interfaces;
using LudoGame.User.Infrastructure.DataBase;
using LudoGame.User.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using LudoGame.User.Application.Calculator.Handlers;
using LudoGame.User.Application.Startup;
using LudoGame.User.Infrastructure.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//builder.Services.AddDbContextPool<ApplicationDbContext>(opt => opt.UseNpgsql("Server=localhost;Port=5432;Database=LudoGame;Username=postgres;Password=123456;"));
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped<ICalculateService,CalculateService>();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CalculateService).Assembly));

builder.Services
    .ConfigureApplicationServices()
    .ConfigureInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


//app.MapPost("/calculate", async (CalculateModel model,ICalculateService service) =>
//{
//    Console.WriteLine($"check -> {model}");
//    //var service = new CalculateService();
//    return await service.Calculate(model);
//}
//    );

//app.Map("/calculate-handler", async (CreateOperationCommand command, IMediator mediator) =>
//{
//    return await mediator.Send(command);
//});

app.MapGet("/our-very-first-api", () =>
{
    return "ok";
});


app.Run();
