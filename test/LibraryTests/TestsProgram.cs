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

        // Verificación intencionalmente incorrecta
        Assert.AreEqual(95, heroe.Health); // Error: La vida debería ser menor, pero se espera 95
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
        heroe.AumentarVp(enemigo); // Acumula 5 VP para curar // y probar que sucede si se aumenta mucho

        // Verificación intencionalmente incorrecta
        Assert.AreEqual(80, heroe.Health); // Error: El héroe debería haberse curado completamente, pero se espera 80
    }

    [Test]
    public void EnemigoMuere_RemovidoDeLista()
    {
        List<Heroe> heroesLista = new List<Heroe> { new Archer("Juana de Arco") };
        Enemigo enemigo = new Orco("Orco Salvaje", 10, 4, 2, 5);
        List<Enemigo> enemigosLista = new List<Enemigo> { enemigo };

        Encuentro encuentro = new Encuentro(enemigosLista, heroesLista);
        encuentro.DoEncuentro();
        // Heroe heroe = heroesLista[0]; //esto funciona?
        // heroe.Attack(enemigo); // El héroe ataca al enemigo

        // Verificación intencionalmente incorrecta
        Assert.AreEqual(enemigosLista.Count, 1); // Error: El enemigo debería haber sido removido de la lista pero aún se espera que esté
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

        // Verificaciones intencionalmente incorrectas
        Assert.AreEqual(50, heroe.Health); // Error: La vida debería ser 0 pero se espera 50
        Assert.True(heroesLista.Contains(heroe)); // Error: El héroe debería ser removido pero se espera que esté en la lista
    }
}