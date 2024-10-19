using System;
using System.Collections.Generic;
using Library.Afiliacion;
using Library.Batalla;
using Library.Characters;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        List<Enemigo> EnemigosLista = new List<Enemigo>
        {
            Orco orco = new Orco("Orco Salvaje", 20, 4, 2, 5);
            Troll troll = new Troll("Troll de las Montañas", 30, 6, 5, 7);
            Gargola gargola = new Gargola("Gárgola de Piedra", 25, 5, 6, 6);
            Espectro espectro = new Espectro("Espectro Oscuro", 15, 3, 1, 4);
            Belcebu belcebu = new Belcebu("Belcebu", 40, 8, 7, 10);
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