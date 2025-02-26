using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.User.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LudoGame.User.Domain.Player;

namespace LudoGame.User.Infrastructure.Authentication;

public class PlayerManager : UserManager<Player>, IPlayerManager
{
    public PlayerManager(
        IUserStore<Player> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<Player> passwordHasher,
        IEnumerable<IUserValidator<Player>> userValidators,
        IEnumerable<IPasswordValidator<Player>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager<Player>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    { }
}