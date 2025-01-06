using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Models;
using Xmasgame.Interfaces;

namespace Xmasgame.Logic
{
    public  class GameActionHandler : IGameActionHandler
    {
        private readonly Action<GameState> _saveGame;

        public GameActionHandler(Action<GameState> saveGame)
        {
            _saveGame = saveGame;
        }
        public  bool HandleSaveOrQuit(GameState gameState, Func<string> inputProvider) //use mock to test user input  without relying on console
        {
                Console.WriteLine("\nDo you want to (C)ontinue, (S)ave, or (Q)uit?");
                string choice = inputProvider()?.Trim().ToUpper();

                switch (choice) 
                {
                    case "C":
                        return true;
                    case "S":
                        _saveGame(gameState);
                        Console.WriteLine("Game saved. Do you want to (C)ontinue or (Q)uit?");
                        choice = inputProvider()?.Trim().ToUpper();
                        return false;
                    case "Q":
                        Console.WriteLine("Quitting game. See you next time!");
                        return false;
                    default:
                        Console.WriteLine($"Invalid choice: '{choice}'. Expected 'C', 'S', or 'Q'.");
                        return HandleSaveOrQuit(gameState, inputProvider); // Reprompt recursively
            }
        }
    }
}
