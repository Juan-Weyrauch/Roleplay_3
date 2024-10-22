using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Library.Afiliacion;
using Library.Batalla;
using Ucu.Poo.RoleplayGame;


namespace LibraryTests;

// Identifiquen los tests necesarios para incorporar el concepto de encuentro y agreguenlos al proyecto de test.
// Estos tests deben fallar en este punto.

[TestFixture]
public class TestsProgram
{
    private string? nombre_heroe = "Juana de Arco", nombre_enemigo = "Orco Salvaje";

    // Test con errores intencionales
    [Test]
    public void CrearHeroeYEnemigo_Correctamente()
    {
        // Creación de héroe y enemigo

        Heroe heroe = new Archer(nombre_heroe);
        if (heroe != null)
        {
            Enemigo enemigo = new Orco(nombre_enemigo, 20, 20, 0, 5);
            // Verificaciones intencionalmente incorrectas

            try
            {
                string? expected_name = heroe.ObtenerNombre();
                Assert.AreEqual(nombre_heroe, expected_name);
            }
            catch
            {
                Assert.Fail();
            }

            try
            {
                enemigo.Attack(heroe);
                Assert.AreEqual(98, heroe.Health);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.AreEqual(nombre_enemigo, enemigo.ObtenerNombre());
            Assert.AreEqual(20, enemigo.Health); //tiene 18 de defensa por el helmet
        }
    }

    [Test]
    public void HeroeAtaca_EnemigoPierdeVida()
    {
        Heroe heroe = new Archer(nombre_heroe);
        Enemigo enemigo = new Orco(nombre_enemigo, 20, 4, 2, 5);

        heroe.Attack(enemigo);

        Assert.AreEqual(7, enemigo.Health);
    }

    [Test]
    public void EnemigoAtaca_HeroeNoPierdeVida()
    {
        Heroe heroe = new Archer(nombre_heroe);
        Enemigo enemigo = new Orco(nombre_enemigo, 20, 10, 2, 5);

        enemigo.Attack(heroe);

        Assert.AreEqual(100, heroe.Health); // tiene mas defensa que el ataque del enemigo
    }

    [Test]
    public void HeroeCura_DespuesDeGanarVp()
    {
        Heroe heroe = new Archer(nombre_heroe);
        Enemigo enemigo = new Orco(nombre_enemigo, 20, 4, 2, 5);

        for (int i = 0; i < 6; i++) // Acumula 5 VP para curar y probamos que sucede si se aumenta mucho
        {
            heroe.AumentarVp(enemigo);
        }

        Assert.AreEqual(100, heroe.Health); // El héroe debería haberse curado completamente
    }

    [Test]
    public void EnemigoMuere_RemovidoDeLista()
    {
        List<Heroe> heroesLista = new List<Heroe> { new Archer(nombre_heroe) };
        Enemigo enemigo = new Orco(nombre_enemigo, 10, 4, 2, 5);
        List<Enemigo> enemigosLista = new List<Enemigo> { enemigo };

        Encuentro encuentro = new Encuentro(enemigosLista, heroesLista);
        encuentro.DoEncuentro();

        Assert.AreEqual(enemigosLista.Count, 0); //El enemigo debería haber sido removido de la lista 
    }

    [Test]
    public void HeroeMuere_RemovidoDeLista()
    {
        List<Heroe> heroesLista = new List<Heroe> { new Archer(nombre_heroe) };
        Enemigo enemigo = new Orco(nombre_enemigo, 20, 118, 2, 5);
        List<Enemigo> enemigosLista = new List<Enemigo> { enemigo };
        
        Encuentro Inicio = new Encuentro(enemigosLista, heroesLista);
        Inicio.DoEncuentro();
        
        Assert.AreEqual(heroesLista.Count, 0); //El heroe debería haber sido removido de la lista 
    }
}