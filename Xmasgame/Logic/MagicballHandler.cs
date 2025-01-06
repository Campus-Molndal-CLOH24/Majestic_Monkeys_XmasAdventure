using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Models;
using Xmasgame.Interfaces;

namespace Xmasgame.Logic
{
    public  class MagicballHandler : IMagicBallHandler
    {
        private IInputhandler inputhandler;

        public  void SearchMagicBalls(GameState gameState , int? randomValue = null)
        {


            // Generate a random value if none is provided
            int result = randomValue ?? new Random().Next(0, 101);
            if (result <= 40)
            {
                gameState.MagicBallsFound++;
                Console.WriteLine("You found a magic ball!");
            }
            else if (result <= 70)
            {
                Console.WriteLine("Oh Nooooo, Marcus has set a trap!");
                if (inputhandler == null)
                {
                    Console.WriteLine("Input handler is not initialized.");
                    return;
                }
                MarcusHandler.EnconterMarcus(gameState, inputhandler);
            }
            else
            {
                gameState.lives++;
                Console.WriteLine("You get help from Elf !! , now you gain extra life");
            }
            
        }
    }
}
