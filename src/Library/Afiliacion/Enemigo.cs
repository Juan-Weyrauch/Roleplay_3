namespace Library.Afiliacion;

public  class Enemigo: Characters
{
   

    Enemigo(string name,int life, int attackValue, int defenseValue, int valorvp) : base(name)
    {
        this.Name = name;
        this.health = life;
        this.DefenseValue = defenseValue; //Como evitar lo de la clase virtual?
        this.AttackValue = attackValue;
        ValorVp = valorvp;
    }

    
}