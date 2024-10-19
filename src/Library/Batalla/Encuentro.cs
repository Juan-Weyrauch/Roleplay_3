using Library.Afiliacion;
using Ucu.Poo.RoleplayGame;

namespace Library.Batalla;

public class Encuentro
{
    List<Enemigo> listaEnemigos;
    List<Heroe> listaHeroes;

    public Encuentro(List<Enemigo> enemigos, List<Heroe> heroes)
    {
        if (enemigos.Count < 1 || heroes.Count < 1)
        {
            throw new ArgumentException("Debe haber al menos un héroe y un enemigo para iniciar el encuentro.");
        }

        this.listaEnemigos = enemigos;
        this.listaHeroes = heroes;
    }

    public void DoEncuentro()
    {
        int turno = 0; // 0 significa turno de enemigos, 1 significa turno de héroes

        while (listaHeroes.Count > 0 && listaEnemigos.Count > 0)
        {
            // Ataques de los enemigos (turno 0)
            if (turno == 0)
            {
                for (int i = 0; i < listaEnemigos.Count; i++)
                {
                    if (listaHeroes.Count == 0) break; // Si no hay más héroes, termina la batalla

                    // Seleccionar héroe de manera cíclica
                    Heroe heroActual = listaHeroes[i % listaHeroes.Count];
                    Enemigo enemigoActual = listaEnemigos[i];

                    enemigoActual.Attack(heroActual);
                    Console.WriteLine($"{enemigoActual.ObtenerNombre()} ataca al héroe {heroActual.ObtenerNombre()}\n");

                    // Si el héroe ha muerto, se elimina de la lista
                    if (heroActual.Health <= 0)
                    {
                        Console.WriteLine(
                            $"{heroActual.ObtenerNombre()} ha muerto a manos de {enemigoActual.ObtenerNombre()}");
                        listaHeroes.Remove(heroActual);
                    }
                }

                turno = 1; // Cambiar al turno de héroes
            }

            // Ataques de los héroes (turno 1)
            else if (turno == 1)
            {
                for (int i = 0; i < listaHeroes.Count; i++)
                {
                    if (listaEnemigos.Count == 0) break; // Si no hay más enemigos, termina la batalla

                    // Seleccionar enemigo de manera cíclica
                    Enemigo enemigoActual = listaEnemigos[i % listaEnemigos.Count];
                    Heroe heroActual = listaHeroes[i];

                    heroActual.Attack(enemigoActual);
                    Console.WriteLine($"{heroActual.ObtenerNombre()} ataca al enemigo {enemigoActual.ObtenerNombre()}\n");

                    // Si el enemigo ha muerto, se elimina de la lista
                    if (enemigoActual.Health <= 0)
                    {
                        Console.WriteLine(
                            $"{enemigoActual.ObtenerNombre()} ha muerto a manos de {heroActual.ObtenerNombre()}");
                        heroActual.AumentarVp(enemigoActual);
                        heroActual.Checkcurar();
                        listaEnemigos.Remove(enemigoActual);
                    }
                }

                turno = 0; // Cambiar al turno de enemigos
            }

            // Verificar si todos los héroes o enemigos han muerto
            if (listaEnemigos.Count == 0)
            {
                Console.WriteLine("¡Los héroes han ganado la batalla!");
                break;
            }

            if (listaHeroes.Count == 0)
            {
                Console.WriteLine("¡Los enemigos han ganado la batalla!");
                break;
            }
        }
    }
}