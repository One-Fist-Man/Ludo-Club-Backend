using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.User.Application.Calculator;

namespace LudoGame.User.Application.Interfaces
{
    public interface ICalculateService
    {
        public Task<int> Calculate(CalculateModel model);
    }
}
