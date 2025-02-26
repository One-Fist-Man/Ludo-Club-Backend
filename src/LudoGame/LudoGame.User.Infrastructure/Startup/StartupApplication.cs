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
using LudoGame.User.Domain;
using LudoGame.User.Domain.Player;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using LudoGame.User.Infrastructure.Abstractions;
using LudoGame.User.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;


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

    private static void AddIdentity(IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<Player>().AddEntityFrameworkStores<ApplicationDbContext>();

        var tokenValidationParameter = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
        };

        services.AddAuthentication(IdentityConstants.BearerScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;
                    cfg.TokenValidationParameters = tokenValidationParameter;

                });

        services.AddScoped<IPlayerManager, PlayerManager>();
        services.AddScoped<IAuthorizationService, AuthenticationService>();
    
    }
}