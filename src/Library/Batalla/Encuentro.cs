using Library.Afiliacion;
using Ucu.Poo.RoleplayGame;

namespace Library.Batalla;

public class  Encuentro
{
    List<Enemigo>  listaEnemigos;
    List<Heroe>     listaHeroes;
    public Encuentro(List<Enemigo> enemigos, List<Heroe> heroes) // los enemigos van primero en el constructor.
    {
        this.listaEnemigos = enemigos;
        this.listaHeroes = heroes;
    }
    public void DoEncuentro() // Se define el metodo como pide la consigna.
    {
        int canitidadInicialHeroes = listaHeroes.Count;
        for (int i = 0; i != canitidadInicialHeroes ; i++)
        { // La lógica de esto es lo que esta mal. falta solucionar ese aspecto.
            Enemigo enemigoActual = listaEnemigos[i];
            Heroe heroActual = listaHeroes[i];
            enemigoActual.Attack(heroActual); // Metodo que permite atacar a un character.
            Console.WriteLine($"{enemigoActual.ObtenerNombre()} ataca a el heroe {heroActual.ObtenerNombre()}");
            if (heroActual.Health <= 0)
            {
                Console.WriteLine($"{heroActual.ObtenerNombre()} ha muerto a manos de {heroActual.ObtenerNombreAsesino()}");
            }
            if (enemigoActual.Health <= 0) 
            {
                 heroActual.AumentarVp(enemigoActual); // Aumenta el valor del vp del hero en base a el valor del muestro
                 heroActual.Checkcurar(); // Checkea si es 5 o mayor para curarlo.
                listaEnemigos.Remove(enemigoActual);
                Console.WriteLine($"{enemigoActual.ObtenerNombre()} ha muerto a manos de {enemigoActual.ObtenerNombreAsesino()}");
            }
        }
        return ;
    }
}