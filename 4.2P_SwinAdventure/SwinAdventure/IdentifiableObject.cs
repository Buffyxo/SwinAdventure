using System;
namespace SwinAdventure
{
	public class IdentifiableObject
	{
		private List<string> _identifiers;

		public IdentifiableObject(string[] idents)
		{
			_identifiers = new List<string>();
			_identifiers.AddRange(idents);
		}

        public bool AreYou(string id)
        {
			bool exists = false;

			foreach(string identifier in _identifiers)
				if (id.Equals(identifier, StringComparison.OrdinalIgnoreCase))
				{
					exists = true;
				}
			return exists;
        }

		public string FirstId
		{
			get
			{
				if (_identifiers.Count > 0)
				{
					return _identifiers[0];
				}
				else
				{
                    return "";
                }
			}
		}

		public void AddIdentifier(string id)
		{
			_identifiers.Add(id.ToLower());
		}

		public void PrivilegeEscalation(string pin)
		{
			if (_identifiers[0].EndsWith(pin))
			{
				_identifiers.RemoveAt(0);
				_identifiers.Insert(0, "COS20007");
			}
		}
    }
}

