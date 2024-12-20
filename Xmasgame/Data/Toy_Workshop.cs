using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Data
{
    public class ToyWorkshop : Rooms
    {
        public ToyWorkshop() 
        {
            RoomsName = "Toy Workshop";
            RoomsDescription = "The magical heart of Santa's operations. " +
                "Elves are busy building toys of all shapes and sizes, their tiny hammers and saws clinking in rhythm. " +
                "The shelves are overflowing with dolls, trains, and colorful boxes. " +
                "Glittering magic fills the air, making everything feel alive.";
            Items = new List<Items>
                {
                    new Items(ItemID: 2, ItemName: "Christmas saws", IsMagical: true, description: "Perfect cut the tree!")
                };
        }
        
    }
}
