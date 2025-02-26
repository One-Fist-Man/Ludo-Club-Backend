using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverAspirants.Common;

namespace LudoGame.User.Domain.Player;

public static class PlayerError
{
    public static Error UserNameMissing => new Error("Player.UserNameMissing", "User name is missing");
    public static Error PlayerAlreadyExist => new Error("Player.AlreadyExist", "Player already exists");
    public static Error PlayerCreationFailed => new Error("Player.CreationFailed", "Player creation failed");
}