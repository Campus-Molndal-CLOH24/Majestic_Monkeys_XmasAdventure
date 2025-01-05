using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xmasgame.Data
{
    public class Player
    {
         
        public string name { get; set; }
        public List<Items> Inventory { get; private set; }

        public Player(string name)
        {
            this.name = name;
            Inventory = new List<Items>();
        }

        public bool AddItem(Items item)
        {
            if (item == null)
            {
                return false;
            }
            if (Inventory.Count >= 8) // Du bestämmer själv maxgränsen
            {
                return false; // Inventory fullt!
            }
            Inventory.Add(item);
            return true;
        }
    }
}
