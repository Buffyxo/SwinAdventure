using System;
using SwinAdventure;
using Path = SwinAdventure.Path;

namespace UnitTests
{
    public class MoveCommandUnitTest
    {
        string[] command;
        MoveCommand moveCommand;
        Player player;
        Location hallway;
        Location closet;
        Location garden;
        Path s;
        Path se;
        Path e;
        Path n;
        Path w;

        [SetUp]
        public void Setup()
        {
            player = new Player("player", "A player");

            moveCommand = new MoveCommand();

            // Set available locations
            hallway = new Location("the Hallway", "This is a long well lit hallway.\n");
            closet = new Location("a small Closet", "A small dark closet, with an odd smell\n");
            garden = new Location("a small Garden", "There are many small shrubs and flowers growing from well tended garden beds.\n");

            // Set available paths
            n = new Path(new string[] { "north", "n" }, "North", "You go through a door\n");
            s = new Path(new string[] { "south", "s" }, "South", "You go through a door\n");
            e = new Path(new string[] { "east", "e" }, "East", "You travel through a small door, and then crawl a few meters before arriving from the east\n");
            w = new Path(new string[] { "west", "w" }, "West", "You go through a door\n");
            se = new Path(new string[] { "southeast", "se" }, "Southeast", "You go through a door\n");

            // Set items and paths for Hallway
            hallway.AddPath(s, closet);
            hallway.AddPath(se, garden);
            se.isLocked = true;

            // Set items and paths for Closet
            closet.AddPath(n, hallway);
            closet.AddPath(e, garden);

            // Set items and paths for Garden
            garden.AddPath(w, closet);

            // Prepare initial location
            player.Location = hallway;

        }

        [Test]
        public void TestValidMoveCommands()
        {
            string[] validCommands = { "move", "go", "head", "leave" };
            string actual = "";
            string expected = "";

            foreach (String validCommand in validCommands)
            {
                command = new String[] { validCommand, "s" };
                actual = moveCommand.Execute(player, command);
                expected = s.FullDescription + "You have arrived in " + player.Location.Name;

                Assert.That(actual == expected);

                command = new String[] { validCommand, "n" };
                moveCommand.Execute(player, command);
            }

        }

        [Test]

        public void TestInvalidPaths()
        {
            string[] validCommands = { "move", "go", "head", "leave" };
            string actual = "";
            string expected = "";

            foreach (String validCommand in validCommands)
            {
                command = new String[] { validCommand, "sw" };
                actual = moveCommand.Execute(player, command);
                expected = "There are no paths that lead there.";

                Assert.That(actual == expected);

            }
        }

        [Test]

        public void TestInvalidMoveCommand()
        {
            string[] validCommands = { "move", "go", "head", "leave" };
            string actual = "";
            string expected = "";

            foreach (String validCommand in validCommands)
            {
                command = new String[] { validCommand, "to", "sw" };
                actual = moveCommand.Execute(player, command);
                expected = "That is an invalid move command.";

                Assert.That(actual == expected);

            }
        }

        [Test]
        public void TestMovePlayer()
        {
            string[] command = { "move", "s" };
            moveCommand.Execute(player, command);
            Location actual = player.Location;
            Location expected = closet;

            Assert.That(actual == expected);
        }

        [Test]
        public void TestLockedPath()
        {

            string[] command = { "move", "se" };
            string actual = moveCommand.Execute(player, command);
            string expected = "You need to unlock this path to go there.";

            Assert.That(actual == expected);
        }


    }
}

