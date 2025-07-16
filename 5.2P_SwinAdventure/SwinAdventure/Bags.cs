using System;
namespace SwinAdventure
{
	public class Bags : Item
	{
		private Inventory _inventory;

		public Bags(string[] ids, string name, string desc) : base (ids, name, desc)
		{
			_inventory = new Inventory();
		}

		public GameObject Locate(string id)
		{
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }

		public override string FullDescription
		{
			get
			{
				return "In the " + Name + " you can see: " + _inventory.ItemList;
			}
		}

		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}

	}
}

