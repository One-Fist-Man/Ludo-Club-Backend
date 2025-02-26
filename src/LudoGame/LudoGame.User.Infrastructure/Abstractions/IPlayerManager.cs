using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.User.Domain.Player;
using Microsoft.AspNetCore.Identity;

namespace LudoGame.User.Infrastructure.Abstractions;

public interface IPlayerManager
{
    public Task<Player> FindByNameAsync(string UserName);
    public Task<IdentityResult> CreateAsync(Player player, string password);
}
