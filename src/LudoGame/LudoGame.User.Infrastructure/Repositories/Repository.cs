using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.User.Application.Interfaces;
using LudoGame.User.Infrastructure.DataBase;

namespace LudoGame.User.Infrastructure.Repositories;

    public class Repository<T>(ApplicationDbContext dbContext):IRepository<T>
    {
    private readonly  ApplicationDbContext _dbContext= dbContext;

    public async Task AddAsync(T entity)
    {
        if (entity is null) return;
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
     }
    }

