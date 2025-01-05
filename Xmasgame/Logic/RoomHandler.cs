using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Data;
using Xmasgame.Models;
using Xmasgame.UI;
using Xmasgame.Interfaces;

namespace Xmasgame.Logic
{
    //the room-related logic (room choice, entering, showing items) it will refer to command handler to start new game and load game
    public  class RoomHandler : IRoomhandler
    {
        private readonly IInputhandler _inputHandler;
        public RoomHandler(IInputhandler inputHandler)
        {
            _inputHandler = inputHandler;
        }
        
        public void HandlerRoomChoice(GameState gameState) 
        {
            List<Rooms> rooms = new List<Rooms>
            {
                new Livingroom(),
                new ToyWorkshop(),
                new SnowyForest()
            };
            // Extract room names to pass to InputHandler
            string[] roomsNames = rooms.Select(r => r.RoomsName!).ToArray();
            //call Inputhandle to get user choice by index 
            int chosenRoom = _inputHandler.GetRoomchoice(roomsNames, Console.ReadLine);
            //Acces the chosen room and show detail
            Rooms Getrooms = rooms[chosenRoom];
            Console.WriteLine($"\nYou are entering the {Getrooms.RoomsName}...");
            Console.WriteLine(Getrooms.RoomsDescription);

            // Display items in the room (if any)
            if (Getrooms.Items != null && Getrooms.Items.Any())
            {
                System.Console.WriteLine();
                Console.WriteLine("You see the following items:");
                foreach (var item in Getrooms.Items)
                {
                    Console.WriteLine($" {item.ItemName} - {item.Description}");
                }
            }
            else
            {
                Console.WriteLine("There are no items in this room.");
            }
        }
    }
}
