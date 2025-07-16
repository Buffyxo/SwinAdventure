namespace UnitTests;

using System.Xml.Linq;
using SwinAdventure;

public class ItemUnitTests
{
    Item item1;

    [SetUp]
    public void Setup()
    {
        item1 = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel.");

    }

    [Test]
    public void TestItemIsIdentifiable()
    {
        Assert.IsTrue(item1.AreYou("shovel"));
    }


    [Test]
    public void TestShortDescription()
    {
        Assert.That(item1.ShortDescription == "a shovel (shovel)");
    }

    [Test]
    public void TestFullDescription()
    {
        Assert.That(item1.FullDescription == "This is a shovel.");
    }

}
