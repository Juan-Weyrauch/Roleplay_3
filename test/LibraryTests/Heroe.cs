using Ucu.Poo.RoleplayGame;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit;




namespace Library.Tests
{
    [TestFixture]
    public class EncuentroTests
    {
        [Test]
        public void test_batalla_con_un_heroe_un_enemigo()
        {
            // Configuración de la prueba: 1 héroe vs 1 enemigo
            List<Enemigo> listaEnemigos = new List<Enemigo>
            {
                new Orco("Orco Salvaje", 10, 4, 2, 5)
            };

            List<Heroe> listaHeroes = new List<Heroe>
            {
                new Archer("Juana de Arco")
            };

            Encuentro batalla = new Encuentro(listaEnemigos, listaHeroes);

            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que el ganador es coherente
            Assert.IsTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }

        [Test]
        public void test_batalla_con_un_solo_heroe_y_varios_enemigos()
        {
            // Configuración de la prueba: 1 héroe vs varios enemigos
            List<Enemigo> listaEnemigos = new List<Enemigo>
            {
                new Orco("Orco Salvaje", 20, 4, 2, 5),
                new Troll("Troll de las Montañas", 30, 6, 5, 7)
            };

            List<Heroe> listaHeroes = new List<Heroe>
            {
                new Archer("Juana de Arco")
            };

            Encuentro batalla = new Encuentro(listaEnemigos, listaHeroes);

            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que el ganador es coherente
            Assert.isTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }

        [Test]
        public void test_batalla_con_muchos_heroes_y_enemigos()
        {
            // Configuración de la prueba: muchos héroes y enemigos (prueba de resistencia)
            List<Enemigo> listaEnemigos = new List<Enemigo>
            {
                new Orco("Orco Salvaje", 50, 10, 5, 10),
                new Troll("Troll de las Montañas", 70, 12, 10, 15),
                new Gargola("Gárgola de Piedra", 60, 8, 7, 12),
                new Espectro("Espectro Oscuro", 40, 7, 3, 8),
                new Belcebu("Belcebu", 100, 15, 12, 20)
            };

            List<Heroe> listaHeroes = new List<Heroe>
            {
                new Archer("Juana de Arco"),
                new Knight("Sir Lancelot"),
                new Wizard("Merlin"),
                new Knight("Rey Arturo"),
                new Wizard("Gandalf")
            };

            Encuentro batalla = new Encuentro(listaEnemigos, listaHeroes);

            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que todos los héroes o enemigos han sido eliminados
            Assert.IsTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }

        [Test]
        public void test_batalla_con_un_solo_heroe()
        {
            // Configuración de la prueba: solo 1 héroe
            List<Enemigo> listaEnemigos = new List<Enemigo>
            {
                new Orco("Orco Salvaje", 20, 4, 2, 5)
            };

            List<Heroe> listaHeroes = new List<Heroe>
            {
                new Archer("Juana de Arco")
            };

            Encuentro batalla = new Encuentro(listaEnemigos, listaHeroes);
    
            // Ejecutar el encuentro
            Assert.DoesNotThrow(() => batalla.DoEncuentro(), "El encuentro debería ejecutarse sin errores.");
            // Verificar que el ganador es coherente
            Assert.IsTrue(listaEnemigos.Count == 0 || listaHeroes.Count == 0, "La batalla debe terminar con todos los héroes o todos los enemigos derrotados.");
        }   
    }
}