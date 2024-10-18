using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Archer : Characters
{

    public Archer(string name) : base(name)
    {
        this.Name = name;

        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }

}