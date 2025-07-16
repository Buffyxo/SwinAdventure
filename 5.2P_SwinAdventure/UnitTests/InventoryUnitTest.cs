namespace UnitTests;

using System.Xml.Linq;
using SwinAdventure;

public class InventoryUnitTests
{
    Inventory newInventory;
    Item shovel;
    Item rock;

    [SetUp]
    public void Setup()
    {
        newInventory = new Inventory();
        shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel.");
        rock = new Item(new string[] { "rock", "stone" }, "a rock", "This is a rock.");

        newInventory.Put(shovel);
        newInventory.Put(rock);
    }

    [Test]
    public void TestFindItem()
    {
        Assert.That(newInventory.HasItem("shovel") == true);
        Assert.That(newInventory.HasItem("rock") == true);
    }


    [Test]
    public void TestNoItemFind()
    {
        Assert.That(newInventory.HasItem("shoe") == false);
    }


    [Test]
    public void TestFetchItem()
    {
        newInventory.Fetch("shovel");

        Assert.That(newInventory.Fetch("shovel") == shovel);
        Assert.That(!(newInventory.Fetch("shovel") == null));

        string id = "shovel";
        Assert.That(newInventory.Fetch(id) == shovel);
    }

    [Test]
    public void TestTakeItem()
    {
        newInventory.Take("shovel");
        Assert.That(newInventory.HasItem("shovel") == false);
    }

    [Test]
    public void TestItemList()
    {
        string actual = newInventory.ItemList;
        string expected = "\n\ta shovel (shovel)\n\ta rock (rock)";

        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(!(actual == null));
    }

}
