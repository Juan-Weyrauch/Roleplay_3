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
    // Test con errores intencionales
    [Test]
    public void CrearHeroeYEnemigo_Correctamente()
    {
        // Creación de héroe y enemigo
        Heroe heroe = new Archer("Juana de Arco");
        Enemigo enemigo = new Orco("Orco Salvaje", 20, 4, 2, 5);

        // Verificaciones intencionalmente incorrectas
        Assert.AreEqual("Joan of Arc", heroe.ObtenerNombre()); // Error: El nombre debería ser "Juana de Arco" (tremendo nombre)
        Assert.AreEqual(50, heroe.Health); // Error: La vida inicial es 100, pero se espera 50
        Assert.AreEqual("Wild Orc", enemigo.ObtenerNombre()); // Error: El nombre debería ser "Orco Salvaje"
        Assert.AreEqual(10, enemigo.Health); // Error: La vida inicial es 20, pero se espera 10
    }

    [Test]
    public void HeroeAtaca_EnemigoPierdeVida()
    {
        Heroe heroe = new Archer("Juana de Arco");
        Enemigo enemigo = new Orco("Orco Salvaje", 20, 4, 2, 5);

        heroe.Attack(enemigo);

        // Verificación intencionalmente incorrecta
        Assert.AreEqual(15, enemigo.Health); // Error: La vida debería ser menor, pero se espera 15
    }

    [Test]
    public void EnemigoAtaca_HeroePierdeVida()
    {
        Heroe heroe = new Archer("Juana de Arco");
        Enemigo enemigo = new Orco("Orco Salvaje", 20, 10, 2, 5);

        enemigo.Attack(heroe);

        Assert.AreEqual(90, heroe.Health); // 100 de vida - 10 de daño
    }

    [Test]
    public void HeroeCura_DespuesDeGanarVp()
    {
        Heroe heroe = new Archer("Juana de Arco");
        Enemigo enemigo = new Orco("Orco Salvaje", 20, 4, 2, 5);

        heroe.AumentarVp(enemigo);
        heroe.AumentarVp(enemigo);
        heroe.AumentarVp(enemigo);
        heroe.AumentarVp(enemigo);
        heroe.AumentarVp(enemigo); // Acumula 5 VP para curar y probamos que sucede si se aumenta mucho

        Assert.AreEqual(100, heroe.Health); // El héroe debería haberse curado completamente
    }

    [Test]
    public void EnemigoMuere_RemovidoDeLista()
    {
        List<Heroe> heroesLista = new List<Heroe> { new Archer("Juana de Arco") };
        Enemigo enemigo = new Orco("Orco Salvaje", 10, 4, 2, 5);
        List<Enemigo> enemigosLista = new List<Enemigo> { enemigo };

        Encuentro encuentro = new Encuentro(enemigosLista, heroesLista);
        encuentro.DoEncuentro();

        Assert.AreEqual(enemigosLista.Count, 0); //El enemigo debería haber sido removido de la lista 
    }

    [Test]
    public void HeroeMuere_RemovidoDeLista()
    {
        List<Heroe> heroesLista = new List<Heroe> { new Archer("Juana de Arco") };
        Enemigo enemigo = new Orco("Orco Salvaje", 20, 100, 2, 5);
        List<Enemigo> enemigosLista = new List<Enemigo> { enemigo };
        Encuentro encuentro = new Encuentro(enemigosLista, heroesLista);

        Heroe heroe = heroesLista[0]; 
        enemigo.Attack(heroe);

        Assert.AreEqual(0, heroe.Health); // La vida debería ser 0
        Assert.AreEqual(heroesLista.Count, 0); //El heroe debería haber sido removido de la lista 
    }
}