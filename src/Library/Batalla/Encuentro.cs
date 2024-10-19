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

    public void DoEncuentro()
    {
        // Mientras haya héroes y enemigos vivos
        while (listaHeroes.Count > 0 && listaEnemigos.Count > 0)
        {
            // Los enemigos atacan primero
            for (int i = 0; i < listaEnemigos.Count; i++)
            {
                Enemigo enemigoActual = listaEnemigos[i];
                // Selecciona al héroe que será atacado (ciclo entre héroes si hay más enemigos que héroes)
                Heroe heroActual = listaHeroes[i % listaHeroes.Count];

                enemigoActual.Attack(heroActual); // El enemigo ataca al héroe
                Console.WriteLine($"{enemigoActual.ObtenerNombre()} ataca al heroe {heroActual.ObtenerNombre()}");
                // Verificar si el héroe ha muerto
                if (heroActual.Health <= 0)
                {
                    Console.WriteLine(
                        $"{heroActual.ObtenerNombre()} ha muerto a manos de {enemigoActual.ObtenerNombre()}");
                    listaHeroes.Remove(heroActual); // Eliminar héroe de la lista
                    if (listaHeroes.Count == 0) break; // Si ya no quedan héroes, el encuentro termina
                }
            }

            // Los héroes que sobreviven contraatacan
            List<Enemigo> enemigosMuertos = new List<Enemigo>();
            foreach (Heroe hero in listaHeroes)
            {
                foreach (Enemigo enemigo in listaEnemigos)
                {
                    if (enemigo.Health > 0)
                    {
                        hero.Attack(enemigo); // El héroe ataca al enemigo
                        Console.WriteLine($"{hero.ObtenerNombre()} ataca al enemigo {enemigo.ObtenerNombre()}");

                        // Verificar si el enemigo ha muerto
                        if (enemigo.Health <= 0)
                        {
                            Console.WriteLine($"{enemigo.ObtenerNombre()} ha muerto a manos de {hero.ObtenerNombre()}");
                            hero.AumentarVp(enemigo); // Aumentar VP del héroe
                            hero.Checkcurar(); // Curar si el héroe tiene 5 o más VP
                            enemigosMuertos.Add(enemigo); // Marcar al enemigo para eliminar después
                        }
                    }
                }
            }

            // Remover enemigos muertos después de la batalla
            foreach (Enemigo enemigoMuerto in enemigosMuertos)
            {
                listaEnemigos.Remove(enemigoMuerto);
            }

            // Si todos los enemigos están muertos, el encuentro termina
            if (listaEnemigos.Count == 0)
            {
                Console.WriteLine("¡Los héroes han ganado la batalla!");
                break;
            }

            // Si todos los héroes han muerto, el encuentro termina
            if (listaHeroes.Count == 0)
            {
                Console.WriteLine("¡Los enemigos han ganado la batalla!");
                break;
            }
        }
    }
}