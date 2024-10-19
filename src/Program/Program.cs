using System;
using System.Collections.Generic;
using Library.Afiliacion;
using Library.Batalla;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        List<Enemigo> EnemigosLista = new List<Enemigo>();
       Enemigo Goblin1 = new Enemigo("Goblin",3,15,3,3);
       Enemigo Goblin2 = new Enemigo("Goblin",3,15,3,3);
       Enemigo Goblin3 = new Enemigo("Goblin",3,15,3,3);
       EnemigosLista.Add(Goblin1);
       EnemigosLista.Add(Goblin2);
       EnemigosLista.Add(Goblin3);
       List<Heroe> HeroesLista = new List<Heroe>();
       Heroe Arquero = new Archer("Juana de Arco");
       Heroe SoldadoReino = new Knight("Sir Lancelot");
       Heroe Merlin = new Wizard("Merlin");
       HeroesLista.Add(Arquero);
       HeroesLista.Add(SoldadoReino);
       HeroesLista.Add(Merlin);
       
       Encuentro Instacia = new Encuentro(EnemigosLista, HeroesLista);
       Instacia.DoEncuentro();
       

    }
}
