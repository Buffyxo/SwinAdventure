using System;
using SwinAdventure;
using static System.Net.Mime.MediaTypeNames;
using Path = SwinAdventure.Path;
namespace UnitTests
{
    public class CommandProcessorUnitTest
    {
        CommandProcessor processor;
        Player player;
        Item gem;
        Location hallway;
        Location garden;
        Path se;

        [SetUp]
        public void Setup()
        {
            processor = new CommandProcessor();
            player = new Player("Xena", "A player from the warrior class.");
            gem = new Item(new string[] { "Gem" }, "Gem", "Uncut emerald.");

            // Set available locations
            hallway = new Location("the Hallway", "This is a long well lit hallway.\n");
            garden = new Location("a small Garden", "There are many small shrubs and flowers growing from well tended garden beds.\n");

            // Set available paths
            se = new Path(new string[] { "southeast", "se" }, "Southeast", "You go through a door\n");

            // Set items and paths for Hallway
            hallway.AddPath(se, garden);
            se.isLocked = true;

            // Prepare initial location
            player.Location = hallway;
        }

        [Test]
        public void TestLookCommand()
        {
            string[] input = new String[] { "look", "at", "me" };
            string expected = "\n" + player.FullDescription;
            string actual = processor.ExecuteCommand(player, input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMoveCommand()
        {
            string[] input = new String[] { "move", "se" };
            string expected = "You need to unlock this path to go there.";
            string actual = processor.ExecuteCommand(player, input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestTakeCommand()
        {
            hallway.Inventory.Put(gem);
            string[] input = new String[] { "take", "gem" };
            string expected = "\nYou have taken the " + gem.ShortDescription;
            string actual = processor.ExecuteCommand(player, input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestDropCommand()
        {
            player.Inventory.Put(gem);
            string[] input = new String[] { "drop", "gem" };
            string expected = "\nYou have dropped the " + gem.ShortDescription;
            string actual = processor.ExecuteCommand(player, input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestInventoryCommand()
        {
            string[] input = new String[] { "inv" };
            string expected = "Your inventory contains:" + player.Inventory.ItemList;
            string actual = processor.ExecuteCommand(player, input);
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}

