using Library.Afiliacion;

namespace Ucu.Poo.RoleplayGame;

public class Orco : Enemigo
{
    public Orco(string name, int life, int attackValue, int defenseValue, int valorvp)
        : base(name, life, attackValue, defenseValue, valorvp)
    {
    }
}