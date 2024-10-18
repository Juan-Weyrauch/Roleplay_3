using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Wizard : MagicCharacter
{
    public Wizard(string name) : base(name)
    {
        this.Name = name;

        this.AddItem(new Staff());
    }
}