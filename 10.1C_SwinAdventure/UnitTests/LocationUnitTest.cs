using System;
using System.Numerics;
using SwinAdventure;

namespace UnitTests
{
    public class LocationUnitTest
    {
        private Location hallway;
        private Player player;
        private Item sword;

        [SetUp]
        public void Setup()
        {
            hallway = new Location("the Hallway", "This is a long well lit hallway.");
            player = new Player("Rabbit", "A mysterious rabbit");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
            player.Location = hallway;
        }

        [Test]
        public void TestLocationIdentifyItself()
        {
            Assert.That(hallway.AreYou("location") == true);
        }

        [Test]
        public void TestLocationCanLocateItems()
        {
            hallway.Inventory.Put(sword);
            Assert.That(hallway.Locate("sword") == sword);
        }

        [Test]
        public void TestPlayerLocateItemsInLocation()
        {
            Assert.That(player.Locate("location") == hallway);
        }
    }
}

