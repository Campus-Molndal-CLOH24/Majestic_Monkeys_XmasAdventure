using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.UI
{
    // link to game state to uppdated variables
    public static class GameDisplay
    {
        public static void ShowProgress(string playerName, int magicBallsFound, int totalMagicBalls, int lives) 
        {
            Console.WriteLine($"\n=== Current Progress  of {playerName}===");
            Console.WriteLine($"Magic Balls Found: {magicBallsFound}/{totalMagicBalls}");
            Console.WriteLine($"Lives Remaining: {lives}");
            Console.WriteLine("=========================\n");
        }
    }
}
