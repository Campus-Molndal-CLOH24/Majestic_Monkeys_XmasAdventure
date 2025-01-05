using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Interfaces;

namespace Xmasgame.UI
{
    public  class InputHandler : IInputhandler
    {
        public int GetRoomchoice(string[] rooms, Func<string> inputProvider)
        {
            while (true)
            {

                // display only list where player want to go 
                Console.WriteLine("\nChoose a room to go : ");
                for (int i = 0; i < rooms.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {rooms[i]}");
                }
                //handle with choice i tried without before it was a forever run all the times >0<
                //so we need it to handle with choice which we use index to handle it. 
                Console.Write("Enter your choice: ");
                string userInput = inputProvider(); // use inputProvider to get input instead of Console.ReadLine() directly
                if (int.TryParse(userInput, out int roomChoice) && roomChoice >= 1 && roomChoice <= rooms.Length)
                {
                    Console.WriteLine($"You chose option {roomChoice}");
                    return roomChoice - 1; // Convert to zero-based index
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}