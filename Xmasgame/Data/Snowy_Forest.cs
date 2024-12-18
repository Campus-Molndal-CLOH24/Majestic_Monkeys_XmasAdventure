using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Data
{
    public class Snowy_Forest : Rooms
    {
        public Snowy_Forest() 
        {
            RoomsName = "Snowy Forest";
            RoomsDescription = "You step into a peaceful, snow-covered forest. " +
                "Tall pine trees surround you, their branches heavy with fresh snow. " +
                "The only sounds are the crunch of your boots and the distant hoot of an owl. " +
                "A gentle breeze carries snowflakes that sparkle like stars as they drift down.";
            Items = new List<Items>
                {
                    new Items(ItemID: 3, ItemName: "snowflakes", IsMagical: true, description: "Perfekt för att drink.")
                };
        }
        public List<Items> Items { get; private set; }
    }
}
