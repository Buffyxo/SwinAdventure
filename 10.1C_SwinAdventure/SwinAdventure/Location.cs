using System;
namespace SwinAdventure
{
	public class Location : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private List<Path> _paths;

		public Location(string name, string desc) : base(new string[] { "location" }, name, desc)
		{
			_inventory = new Inventory();
			_paths = new List<Path>();
		}

		public GameObject Locate(string id)
		{
			 if (AreYou(id))
			 {
				return this;
             }

			 foreach (Path path in _paths)
			{
				if (path.AreYou(id))
				{
					return path;
				}
			}

			 return _inventory.Fetch(id);
          
		}



		public string PathList
		{
			get
			{
				string paths = "There are no exits.";

				if (_paths.Count > 0)
				{
                    paths = " and " + _paths[_paths.Count - 1].FirstId;
                    if (_paths.Count > 1)
                    {
                        for (int i = 0; i < _paths.Count - 1; i++)
                        {
                            paths = _paths[i].FirstId + "," + paths;
                        }
                    }
                    else if (_paths.Count == 1)
                    {
                        paths = _paths[0].FirstId;
                    }
                }
				else
				{
					return paths;
				}

				return "There are exits to the " + paths + ".";
			}
		}

		public void AddPath(Path path, Location destination)
        {
			_paths.Add(path);
			path.Destination = destination;
        }

        public override string FullDescription
        {
            get
            {
				return "You are in " + Name + "\n" + base.FullDescription + PathList + "\nIn this room you can see:" + Inventory.ItemList;
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

