using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LudoGame.User.Infrastructure.DbContextes;

public interface IApplicationDbContext
{

}

public sealed class ApplicationDbContext : DbContext , IApplicationDbContext
{

}
