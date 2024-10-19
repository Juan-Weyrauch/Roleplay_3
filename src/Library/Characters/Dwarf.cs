using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Dwarf : Heroe
{
    public Dwarf(string name,int life, int attackValue, int defenseValue) : base(name, life, attackValue, defenseValue)
    {
        this.Name = name;
        this.health = life;
        this.DefenseValue = defenseValue; 
        this.AttackValue = attackValue;

        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }
}