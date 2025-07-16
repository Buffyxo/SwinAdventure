using System;
namespace SwinAdventure
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private Location _location;

		public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
		{
			_inventory = new Inventory();
			
		}

		public GameObject Locate(string id)
		{
			GameObject obj = _inventory.Fetch(id);

            if (AreYou(id))
			{
				return this;
			}
			else if (obj != null)
			{
				return obj;
			}
			else if (_location != null)
			{
				obj = _location.Locate(id);
				return obj;
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

		public Location Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}
	}

	
}

