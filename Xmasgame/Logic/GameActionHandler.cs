﻿using System;
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
        public  bool HandleSaveOrQuit(GameState gameState)
        {
            Console.WriteLine("\nDo you want to (C)ontinue, (S)ave, or (Q)uit?");
            string choice = Console.ReadLine()?.ToUpper();

            if (choice == "S")
            {
                CommandHandler.SaveGame(gameState); //just temporary 
                Console.WriteLine("Game saved. Do you want to (C)ontinue or (Q)uit?");
                choice = Console.ReadLine()?.ToUpper();
            }
            if (choice == "Q")
            {
                Console.WriteLine("Quitting game. See you next time!");
                return false;
            
            }
            return true; // Continue the game if the choice is "C" or any other input
        }
    }
}
