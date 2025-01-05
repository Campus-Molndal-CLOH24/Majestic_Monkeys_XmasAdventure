using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Logic
{
    public static  class MagicballHandler
    {
        public static void SearchMagicBalls(GameState gameState)
        {
            Random random = new Random(); // call randon method
            int result = random.Next(0, 101);
            if (result <= 40)
            {
                gameState.MagicBallsFound++;
                Console.WriteLine("You found a magic ball!");
            }
            else if (result <= 70)
            {
                Console.WriteLine("Oh Nooooo, Marcus has set a trap!");
                MarcusHandler.EnconterMarcus(gameState);
            }
            else
            {
                gameState.lives++;
                Console.WriteLine("You get help from Elf !! , now you gain extra life");
            }
            
        }
    }
}
