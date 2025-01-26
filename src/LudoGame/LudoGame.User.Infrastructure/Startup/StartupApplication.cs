using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LudoGame.User.Infrastructure.DbContextes;
using Microsoft.EntityFrameworkCore;
using LudoGame.User.Application.Common.Interface;
using LudoGame.User.Infrastructure.Repositories;
namespace LudoGame.User.Infrastructure.Startup;

public static class StartupApplication
{
    public static IServiceCollection ConfigureInfrastructureServices( this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LudoGameUserService");
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string isn't found");

        services.AddDbContextPool<IApplicationDbContext, ApplicationDbContext>(
           cfg => cfg.UseNpgsql(connectionString));
       
        AddRepository(services);
        
        return services;
    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}