using SwinAdventure;
namespace UnitTests;

public class IdentifiableObjectTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestAreYou()
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "104673370", "Zakirah", "Adnan" });

        Assert.That(id.AreYou("104673370") == true);
        Assert.That(id.AreYou("Zakirah") == true);
    }

    [Test]
    public void TestNotAreYou()
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "104673370", "Zakirah", "Adnan" });

        Assert.That(id.AreYou("Billie") == false);
        Assert.That(id.AreYou("1o467337o") == false);
    }

    [Test]
    public void TestCaseSensitive()
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "104673370", "Zakirah", "Adnan" });
        Assert.That(id.AreYou("zAkirAh") == true);
    }

    [Test]
    public void TestFirstId()
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "104673370", "Zakirah", "Adnan" });
        Assert.That(id.FirstId == "104673370");
    }

    [Test]
    public void TestFirstIdWithNoIds()
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "" });
        Assert.That(id.FirstId == "");
    }

    [Test]
    public void TestAddId()
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "Seekers", "Athol", "Keith", "Bruce" });
        id.AddIdentifier("Mary");
        Assert.That(id.AreYou("Seekers") == true);
        Assert.That(id.AreYou("Keith") == true);
        Assert.That(id.AreYou("Mary") == true);
    }

    [Test]
    public void TestPrivilegeEscalation()
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "104673370", "Zakirah", "Adnan" });
        id.PrivilegeEscalation("3370");
        Assert.That(id.FirstId == "COS20007");
    }

}