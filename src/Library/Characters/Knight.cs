using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Knight : Character
{

    public Knight(string name) : base(name)
    {
        this.Name = name;

        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }
}