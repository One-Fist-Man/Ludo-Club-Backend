using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LudoGame.User.Domain.Player;

public class Player : IdentityUser
{
    public Name Name { get; set; } 

    private Player(Name name)
    {
        Name = name;
    }

    public static Player Create(Name name)
    {
        return new Player(name);
    }
}