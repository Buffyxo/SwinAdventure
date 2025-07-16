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
        Assert.IsTrue(newInventory.HasItem("shovel"));
        Assert.IsTrue(newInventory.HasItem("rock"));
    }


    [Test]
    public void TestNoItemFind()
    {
        Assert.IsFalse(newInventory.HasItem("shoe"));
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

        Assert.IsFalse(newInventory.HasItem("shovel"));
    }

    [Test]
    public void TestItemList()
    {
        string actual = newInventory.ItemList;
        string expected = "\na shovel (shovel)\na rock (rock)";

        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(!(actual == null));
    }

}
