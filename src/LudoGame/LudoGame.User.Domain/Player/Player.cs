using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LudoGame.User.Domain.Player;

public class Player(Name name) : IdentityUser
{
    public Name Name { get; set; } = name;
}