using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Archer : Heroe
{

    public Archer(string name,int life, int attackValue, int defenseValue) : base(name, life, attackValue, defenseValue)
    {
        this.Name = name;
        this.health = life;
        this.DefenseValue = defenseValue; 
        this.AttackValue = attackValue;

        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }

}