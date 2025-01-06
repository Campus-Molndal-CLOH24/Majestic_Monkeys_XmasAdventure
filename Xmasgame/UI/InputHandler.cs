using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Interfaces;

namespace Xmasgame.UI
{
    public class InputHandler : IInputhandler
    {
        public int GetRoomchoice(string[] rooms, Func<string> inputProvider)
        {
            int maxAttempts = 10; // Set a maximum number of attempts to avoid infinite loop
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                // Display the list of rooms
                Console.WriteLine("\nChoose a room to go : ");
                for (int i = 0; i < rooms.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {rooms[i]}");
                }

                // Handle user choice
                Console.Write("Enter your choice: ");
                string userInput = inputProvider(); // Use inputProvider to get input instead of Console.ReadLine() directly
                if (int.TryParse(userInput, out int index) && index >= 1 && index <= rooms.Length)
                {
                    Console.WriteLine($"You chose option {index}");
                    return index - 1; // Convert to zero-based index
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    attempts++;
                }
            }

            // Return -1 if maximum attempts are reached without valid input
            return -1;
        }
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}