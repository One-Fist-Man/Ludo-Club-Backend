using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.User.Application.Interfaces;

    public interface IRepository<T>
    {
        public Task AddAsync(T entity);
    }

