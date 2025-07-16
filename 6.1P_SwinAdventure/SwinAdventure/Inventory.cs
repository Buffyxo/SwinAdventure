using System;
namespace SwinAdventure
{
	public class Inventory
	{
		private List<Item> _items;

		public Inventory()
		{
			_items = new List<Item>();
		}

		public bool HasItem(string id)
		{
			if (!(Fetch(id) == null))
			{
				return true;
			}
			return false;
		}

		public void Put(Item itm)
		{
			_items.Add(itm);
		}

		public Item Take(string id)
		{
			Item item = Fetch(id);
			_items.Remove(item);
			return item;
        }

		public Item Fetch(string id)
		{
			foreach(Item item in _items)
			{
				if(item.AreYou(id))
				{
					return item;
				}
			}
			return null;
		}

		public string ItemList
		{
			get
			{
				string itemList = "";
				foreach (Item item in _items)
				{
					itemList += "\n" + item.ShortDescription;
				}
				return itemList;

			}
		}

	}
}

