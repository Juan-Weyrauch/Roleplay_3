using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Dwarf : Characters
{
    public Dwarf(string name) : base(name)
    {
        this.Name = name;

        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }
}