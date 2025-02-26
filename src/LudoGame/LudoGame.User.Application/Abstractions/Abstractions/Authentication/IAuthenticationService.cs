using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverAspirants.Common;
using LudoGame.User.Domain.Player;

namespace LudoGame.User.Application.Abstractions.Abstractions.Authentication;

public interface IAuthenticationService
{
    public Task<IResult> RegisterPlayerAsync(Player player, string password);
}