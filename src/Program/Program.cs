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
       Enemigo Goblin1 = new Enemigo("Goblin1",200,125,15,3);
       Enemigo Goblin2 = new Enemigo("Goblin2",200,20,15,3);
       Enemigo Goblin3 = new Enemigo("Goblin3",200,15,15,3);
       EnemigosLista.Add(Goblin1);
       EnemigosLista.Add(Goblin2);
       EnemigosLista.Add(Goblin3);
       List<Heroe> HeroesLista = new List<Heroe>();
       Heroe Arquero = new Archer("Juana de Arco",10,3,3);
       Heroe SoldadoReino = new Knight("Sir Lancelot",15,8,4);
       Heroe Merlin = new Wizard("Merlin",15,5,3);
       HeroesLista.Add(Arquero);
       HeroesLista.Add(SoldadoReino);
       HeroesLista.Add(Merlin);
       
       Encuentro Instacia = new Encuentro(EnemigosLista, HeroesLista);
       Instacia.DoEncuentro();
       

    }
}
