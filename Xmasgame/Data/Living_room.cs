using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Data
{
    public class Livingroom : Rooms
    {
        public Livingroom()
        {
            RoomsName = "Living room";
            RoomsDescription = "A cozy and warm room with a crackling fireplace. " +
                "Christmas stockings hang from the mantel, and the smell of freshly baked cookies fills the air. " +
                "A soft armchair invites you to sit and rest, while faint jingle bells can be heard from somewhere far away.";
            Items = new List<Items>
                {
                    new Items(ItemID: 1, ItemName: "Christmas star", IsMagical: true, description: "Perfekt för att kasta mot Marcus!")
                };
        }

        
    }
}
