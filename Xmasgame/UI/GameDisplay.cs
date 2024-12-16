using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.UI
{
    public class GameDisplay
    {
        public void ShowProgess(string playerName, int magicBallsFound, int totalMagicBalls, int lives, int attemptsLeft) 
        {
            Console.WriteLine("\n=== Current Progress ===");
            Console.WriteLine($"Magic Balls Found: {magicBallsFound}/{totalMagicBalls}");
            Console.WriteLine($"Lives Remaining: {lives}");
            Console.WriteLine($"Attempts Left: {attemptsLeft}");
            Console.WriteLine("=========================\n");
        }
    }
}
