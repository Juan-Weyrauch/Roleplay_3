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
            new Enemigo("Goblin", 3, 15, 3, 3),
            new Enemigo("Pela2", 3, 15, 3, 3),
            new Enemigo("Paragua", 3, 15, 3, 3),
            new Enemigo("jijijaja", 3, 15, 3, 3)
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