using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xmasgame.Data
{
    public class Items
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public bool IsMagical { get; set; }
        public string Description { get; set; }

        public Items(int ItemID, string ItemName, bool IsMagical, string description)
        {
            this.ItemID = ItemID;
            this.IsMagical = false;
            this.ItemName = ItemName;
            this.Description = description;
        }
    }
}
