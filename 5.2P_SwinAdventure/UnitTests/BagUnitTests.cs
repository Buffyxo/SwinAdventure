namespace UnitTests;

using System.Xml.Linq;
using SwinAdventure;

public class BagUnitTests
{
    Bags bag;
    Item shovel;
    Item rock;
    Item lipstick;
    Bags b1;
    Bags b2;

    [SetUp]
    public void Setup()
    {

        b1 = new Bags(new string[] { "Bag 1", "backpack 1" }, "Bag", "a bag");
        b2 = new Bags(new string[] { "Bag 2", "backpack 2" }, "Bag", "a bag");
        bag = new Bags(new string[] { "Bag" , "backpack" }, "Bag", "player's bag");
        shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel.");
        rock = new Item(new string[] { "rock", "stone" }, "a rock", "This is a rock.");
        lipstick = new Item(new string[] { "lipstick", "a lipstick" }, "a lipstick", "This is a lipstick.");

        bag.Inventory.Put(shovel);
        bag.Inventory.Put(rock);
    }

    [Test]
    public void TestBagLocatesItems()
    {
        Assert.That(bag.Locate(shovel.FirstId) == shovel);
    }

    [Test]
    public void TestBagLocatesItself()
    {
        Assert.That(bag.Locate(bag.FirstId) == bag);
    }

    [Test]
    public void TestBagLocatesNothing()
    {
        Assert.That(bag.Locate(lipstick.FirstId) == null);
    }

    [Test]
    public void TestBagFullDescription()
    {
        String expected = bag.Inventory.ItemList;
        String actual = "\na shovel (shovel)\na rock (rock)";
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestBagInBag()
    {
        b1.Inventory.Put(shovel);
        b1.Inventory.Put(b2);
        b2.Inventory.Put(rock);

        Assert.That(b1.Locate(b2.FirstId) == b2);
        // tests that b2 can be locaed in b1

        Assert.That(b1.Locate(shovel.FirstId) == shovel);
        // tests that shovel can be located in b1

        Assert.That(b2.Locate(rock.FirstId) == rock);
        // tests that rock exists in b2

        Assert.That(Equals(b1.Locate(rock.FirstId), b2.Locate(rock.FirstId)) == false);
        // tests that items in b2 cannot be located in b1
    }

    [Test]
    public void TestBagInBagWithAPrivilegedItem()
    {
        b1.Inventory.Put(b2);
        rock.PrivilegeEscalation("privilege");
        b2.Inventory.Put(rock);

        Assert.That(b2.Locate(rock.FirstId) == rock);
        Assert.That(Equals(b1.Locate(rock.FirstId), b2.Locate(rock.FirstId)) == false);
    }




}
