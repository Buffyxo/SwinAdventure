//namespace UnitTests;

//using System.Xml.Linq;
//using SwinAdventure;

//public class LookCommandUnitTests
//{
//    LookCommand look;
//    Player player;
//    Bags bag;
//    Item gem;
  
//    [SetUp]
//    public void Setup()
//    {
//        look = new LookCommand();
//        player = new Player("Xena", "A player from the warrior class.");
//        bag = new Bags(new string[] { "Bag" }, "Bag", "Crafted from cow leather.");
//        gem = new Item(new string[] { "Gem" }, "Gem", "Uncut emerald.");

//        player.Inventory.Put(gem);
//    }

//    [Test]
//    public void TestLookAtMe()
//    {
//        string[] input = new String[] { "look", "at", "me" };
//        string expected = player.FullDescription;
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TestLookAtGem()
//    {
//        string[] input = new String[] { "look", "at", "gem" };
//        string expected = gem.FullDescription;
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TestLookAtUnk()
//    {
//        player.Inventory.Take("Gem");
//        string[] input = new String[] { "look", "at", "gem" };
//        string expected = "I can't find the gem";
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TestLookAtGemInMe()
//    {
//        string[] input = new String[] { "look", "at", "gem", "in", "inventory" };
//        string expected = gem.FullDescription;
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TestLookAtGemInBag()
//    {
//        player.Inventory.Put(bag);
//        player.Inventory.Take("Gem");
//        bag.Inventory.Put(gem);
//        string[] input = new String[] { "look", "at", "gem", "in", "bag" };
//        string expected = gem.FullDescription;
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }


//    [Test]
//    public void TestLookAtGemInNoBag()
//    {
//        string[] input = new String[] { "look", "at", "gem", "in", "bag" };
//        string expected = "I can't find the bag";
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TestLookAtNoGemInBag()
//    {
//        player.Inventory.Put(bag);
//        //player.Inventory.Take("Gem");
//        string[] input = new String[] { "look", "at", "gem", "in", "bag" };
//        string expected = "I can't find the gem";
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }


//    [Test]
//    public void TestInvalidLook()
//    {
//        string[] input = new String[] { "look", "around" };
//        string expected = "I don't know how to look like that\n";
//        string actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));

//        input = new String[] { "see", "the", "gem" };
//        expected = "Error in look input\n";
//        actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));

//        input = new String[] { "look", "in", "gem" };
//        expected = "What do you want to look at?";
//        actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));

//        input = new String[] { "look", "at", "gem", "from", "bag" };
//        expected = "What do you want to look in?";
//        actual = look.Execute(player, input);
//        Assert.That(actual, Is.EqualTo(expected));
//    }







//}
