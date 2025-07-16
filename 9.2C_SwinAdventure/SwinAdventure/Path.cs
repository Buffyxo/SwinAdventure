using System;
using System.Linq;
namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;
        private bool _isLocked;
        

        public Path(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _destination = null;
            _isLocked = false;
            
            
        }

        public string Move(Player p)
        {
            if (_isLocked)
            {
                return "You need to unlock this path to go there.";
            }
            else
            {
                p.Location = _destination;
            }
            return FullDescription + "You have arrived in " + p.Location.Name;
        }

        public Location Destination
        {
            set
            {
                _destination = value;
            }
        }

        public override string FullDescription
        {
            get
            {
                return "\nYou head " + Name + "\n" + base.FullDescription;
            }
        }

        public bool isLocked
        {
            get
            {
                return _isLocked;
            }
            set
            {
                _isLocked = value;
            }
        }

        

    }
}

