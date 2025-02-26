using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ForeverAspirants.Common;
using LudoGame.User.Application.Abstractions.Abstractions.Authentication;
using LudoGame.User.Application.Abstractions.Messaging;
using LudoGame.User.Domain.Player;

namespace LudoGame.User.Application.Players.RegisterPlayer;

public record RegisterPlayerCommand(
    string FirstName,
    string LastName,
    string password
    ): ICommand;

public class RegisterPlayerCommandHandler(IAuthenticationService authenticationService) : ICommandHandler<RegisterPlayerCommand>
{
    private readonly IAuthenticationService _authenticationService=authenticationService;
    public async Task<Result> Handle(RegisterPlayerCommand request, CancellationToken cancellationToken)
    {
        var player = Player.Create(new Name(request.FirstName, request.LastName));
        await _authenticationService.RegisterPlayerAsync(player, request.password);
        return Result.Success;
    }
}
