using Ucu.Poo.RoleplayGame;
using System;
using System.Collections.Generic;
using NUnit.Framework;
    
namespace Library.Tests
{
    [TestFixture]
    public class EncuentroTests
    {
        private List<Enemigo> listaEnemigos;
        private List<Heroe> listaHeroes;
        private Encuentro batalla;

        [SetUp]
        public void SetUp()
        {
            // Inicialización común para las pruebas
            listaEnemigos = new List<Enemigo>();
            listaHeroes = new List<Heroe>();
        }

        [Test]
        public void test_batalla_con_un_heroe_un_enemigo()
        {
            // Configuración de la prueba: 1 héroe vs 1 enemigo
            listaEnemigos.Add(new Orco("Orco Salvaje", 10, 4, 2, 5));
            listaHeroes.Add(new Archer("Juana de Arco"));
            batalla = new Encuentro(listaEnemigos, listaHeroes);

            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que el ganador es coherente
            Assert.IsTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }

        [Test]
        public void test_batalla_con_un_solo_heroe_y_varios_enemigos()
        {
            // Configuración de la prueba: 1 héroe vs varios enemigos
            listaEnemigos.Add(new Orco("Orco Salvaje", 20, 4, 2, 5));
            listaEnemigos.Add(new Troll("Troll de las Montañas", 30, 6, 5, 7));
            listaHeroes.Add(new Archer("Juana de Arco"));
            batalla = new Encuentro(listaEnemigos, listaHeroes);

            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que el ganador es coherente
            Assert.IsTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }

        [Test]
        public void test_batalla_con_muchos_heroes_y_enemigos()
        {
            // Configuración de la prueba: muchos héroes y enemigos
            listaEnemigos.Add(new Orco("Orco Salvaje", 50, 10, 5, 10));
            listaEnemigos.Add(new Troll("Troll de las Montañas", 70, 12, 10, 15));
            listaEnemigos.Add(new Gargola("Gárgola de Piedra", 60, 8, 7, 12));
            listaEnemigos.Add(new Espectro("Espectro Oscuro", 40, 7, 3, 8));
            listaEnemigos.Add(new Belcebu("Belcebu", 100, 15, 12, 20));

            listaHeroes.Add(new Archer("Juana de Arco"));
            listaHeroes.Add(new Knight("Sir Lancelot"));
            listaHeroes.Add(new Wizard("Merlin"));
            listaHeroes.Add(new Knight("Rey Arturo"));
            listaHeroes.Add(new Wizard("Gandalf"));

            batalla = new Encuentro(listaEnemigos, listaHeroes);

            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que todos los héroes o enemigos han sido eliminados
            Assert.IsTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }

        [Test]
        public void test_batalla_con_un_solo_heroe()
        {
            // Configuración de la prueba: solo 1 héroe
            listaEnemigos.Add(new Orco("Orco Salvaje", 20, 4, 2, 5));
            listaHeroes.Add(new Archer("Juana de Arco"));
            batalla = new Encuentro(listaEnemigos, listaHeroes);

            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que el ganador es coherente
            Assert.IsTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }
    }
}
