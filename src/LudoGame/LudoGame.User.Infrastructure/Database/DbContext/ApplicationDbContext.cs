using Microsoft.EntityFrameworkCore;

namespace LudoGame.User.Infrastructure.DataBase;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Operation>? Operations { get; set; }
}