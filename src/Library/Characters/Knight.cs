using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Knight : Heroe
{

    public Knight(string name,int life, int attackValue, int defenseValue) : base(name, life, attackValue, defenseValue)
    {
        this.Name = name;
        this.health = life;
        this.DefenseValue = defenseValue; 
        this.AttackValue = attackValue;

        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }
}