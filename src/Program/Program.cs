using System;
using System.Collections.Generic;
using Library.Afiliacion;
using Library.Batalla;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        List<Enemigo> EnemigosLista = new List<Enemigo>
        {
            new Orco("Orco Salvaje", 20, 4, 2, 5),
            new Troll("Troll de las Montañas", 30, 6, 5, 7),
            new Gargola("Gárgola de Piedra", 25, 5, 6, 6),
            new Espectro("Espectro Oscuro", 15, 3, 1, 4),
            new Belcebu("Belcebu", 40, 8, 7, 10),
        };

        List<Heroe> HeroesLista = new List<Heroe>
        {
            new Archer("Juana de Arco"),
            new Knight("Sir Lancelot"),
            new Wizard("Merlin")
        };

        Encuentro Inicio = new Encuentro(EnemigosLista, HeroesLista);
        Inicio.DoEncuentro();
    }
}