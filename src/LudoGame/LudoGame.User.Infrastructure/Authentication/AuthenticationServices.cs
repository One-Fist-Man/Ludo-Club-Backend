using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.User.Infrastructure.Abstractions;
using LudoGame.User.Application.Abstractions.Abstractions.Authentication;
using ForeverAspirants.Common;
using LudoGame.User.Domain.Player;
namespace LudoGame.User.Infrastructure.Authentication;

public class AuthenticationService(IPlayerManager playerManager):IAuthenticationService
{
    private readonly IPlayerManager _playerManager=playerManager;

    public async Task<IResult> RegisterPlayerAsync(Player player, string password)
    {
        if (string.IsNullOrWhiteSpace(player.UserName))
            return Result.Failure(PlayerError.UserNameMissing);

        var existingUser = _playerManager.FindByNameAsync(player.UserName);
        if (existingUser != null) {
        Result.Failure(PlayerError.PlayerAlreadyExist);
        }

        var result = await _playerManager.CreateAsync(player, password);
        if (result.Succeeded) return Result.Success;

        return Result.Failure(PlayerError.PlayerCreationFailed);

    }
}
