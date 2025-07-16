namespace UnitTests;

using System.Xml.Linq;
using SwinAdventure;

public class LookCommandUnitTests
{
    //LookCommand look;
    CommandProcessor processor;
    // CommandProcesser class declared instead of Look to adjust to the composite
    // relationship of the commands and CommandProcessor class implemented in Iteration 8.
    Player player;
    Bags bag;
    Item gem;

    [SetUp]
    public void Setup()
    {
        //look = new LookCommand();
        processor = new CommandProcessor();
        player = new Player("Xena", "A player from the warrior class.");
        bag = new Bags(new string[] { "Bag" }, "Bag", "Crafted from cow leather.");
        gem = new Item(new string[] { "Gem" }, "Gem", "Uncut emerald.");

        player.Inventory.Put(gem);
    }

    [Test]
    public void TestLookAtMe()
    {
        string[] input = new String[] { "look", "at", "me" };
        string expected = "\n" + player.FullDescription;
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtGem()
    {
        string[] input = new String[] { "look", "at", "gem" };
        string expected = "\n" + gem.FullDescription;
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtUnk()
    {
        player.Inventory.Take("Gem");
        string[] input = new String[] { "look", "at", "gem" };
        string expected = "I can't find the gem.";
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtGemInMe()
    {
        string[] input = new String[] { "look", "at", "gem", "in", "inventory" };
        string expected = "\n" + gem.FullDescription;
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtGemInBag()
    {
        player.Inventory.Put(bag);
        player.Inventory.Take("Gem");
        bag.Inventory.Put(gem);
        string[] input = new String[] { "look", "at", "gem", "in", "bag" };
        string expected = "\n" + gem.FullDescription;
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }


    [Test]
    public void TestLookAtGemInNoBag()
    {
        string[] input = new String[] { "look", "at", "gem", "in", "bag" };
        string expected = "I can't find the bag.";
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtNoGemInBag()
    {
        player.Inventory.Put(bag);
        //player.Inventory.Take("Gem");
        string[] input = new String[] { "look", "at", "gem", "in", "bag" };
        string expected = "I can't find the gem.";
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }


    [Test]
    public void TestInvalidLook()
    {
        string[] input = new String[] { "look", "around" };
        string expected = "I don't know how to look like that.";
        string actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));

        input = new String[] { "see", "the", "gem" };
        expected = "That is an invalid command.";
        actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));

        input = new String[] { "look", "in", "gem" };
        expected = "That is an invalid look command.";
        actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));

        input = new String[] { "look", "at", "gem", "from", "bag" };
        expected = "What do you want to look in?";
        actual = processor.ExecuteCommand(player, input);
        Assert.That(actual, Is.EqualTo(expected));
    }

}
