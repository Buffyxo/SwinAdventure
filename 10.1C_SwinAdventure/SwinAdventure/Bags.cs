using System;
namespace SwinAdventure
{
	public class Bags : Item, IHaveInventory
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
				if (_inventory.ItemList.Length > 0)
				{

                    return base.FullDescription + "\nYou look in the " + Name + " and see: " + _inventory.ItemList;
                }
				return base.FullDescription + "\nThere is nothing in the bag.";
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

