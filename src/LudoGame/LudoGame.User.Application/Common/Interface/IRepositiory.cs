using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.User.Domain;

namespace LudoGame.User.Application.Common.Interface;

public interface IRepository<T> where T: Entity
{

}