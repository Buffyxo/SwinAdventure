using System;
namespace SwinAdventure
{
	public class Player : GameObject
	{
		private Inventory _inventory;

		public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
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
				return "You are " + Name + ", " + base.FullDescription + ". You are carrying: " + _inventory.ItemList;
				
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

