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

            int chosenRoom;
            while (true)
            {
                // Call InputHandler to get user choice by index
                chosenRoom = _inputHandler.GetRoomchoice(roomsNames, Console.ReadLine);

                // Validate the chosen room index
                if (chosenRoom >= 0 && chosenRoom < rooms.Count)
                {
                    break; // Exit the loop if the choice is valid
                }
                else
                {
                    Console.WriteLine("Invalid room choice. Please try again.");
                }
            }

            // Access the chosen room and show details
            Rooms Getrooms = rooms[chosenRoom];
            Console.WriteLine($"\nYou are entering the {Getrooms.RoomsName}...");
            Console.WriteLine(Getrooms.RoomsDescription);

            // Display items in the room (if any)
            if (Getrooms.Items != null && Getrooms.Items.Any())
            {
                Console.WriteLine();
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
