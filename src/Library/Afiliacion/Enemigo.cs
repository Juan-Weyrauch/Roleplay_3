namespace Ucu.Poo.RoleplayGame;

public class Enemigo: Characters
{
   

    public Enemigo(string name,int life, int attackValue, int defenseValue, int valorvp) : base(name)
    {
        this.Name = name;
        this.health = life;
        this.DefenseValue = defenseValue; //Como evitar lo de la clase virtual?
        this.AttackValue = attackValue;
        ValorVp = valorvp;
    }

    public int ObtenerValorVp()
    {
        return ValorVp;
    }
    

    
}