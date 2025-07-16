namespace UnitTests;

using System.Xml.Linq;
using SwinAdventure;

public class PlayerUnitTests
{
    Player newPlayer;
    Item shovel;
    Item rock;

    [SetUp]
    public void Setup()
    {
        newPlayer = new Player("Player", "A player");
        shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel.");
        rock = new Item(new string[] { "rock", "stone" }, "a rock", "This is a rock.");

        newPlayer.Inventory.Put(shovel);
        newPlayer.Inventory.Put(rock);
    }

    [Test]
    public void TestPlayerIsIdentifiable()
    {
        Assert.That(newPlayer.AreYou("me") == true);
    }


    [Test]
    public void TestPlayerLocatesItems()
    {
        Assert.That(newPlayer.Locate("shovel") == shovel);
        Assert.That(newPlayer.Locate("rock") == rock);
    }


    [Test]
    public void TestPlayerLocatesItself()
    {

        Assert.That(newPlayer.Locate("me") == newPlayer);
    }

    [Test]
    public void TestPlayerLocatesNothing()
    {
        Assert.That(newPlayer.Locate("cherry") == null);
    }

    [Test]
    public void TestPlayerFullDescription()
    {
        Assert.That(newPlayer.FullDescription == "You are Player, A player. You are carrying: \n\ta shovel (shovel)\n\ta rock (rock)");
    }


}
