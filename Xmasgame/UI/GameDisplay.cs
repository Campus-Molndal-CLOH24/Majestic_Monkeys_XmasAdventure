using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Interfaces;

namespace Xmasgame.UI
{
    // link to game state to uppdated variables
    public class GameDisplay : IGameDisplay
    {
        public void ShowMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowWarning(string warning)
        {
            ShowMessage($"[WARNING]: {warning}", ConsoleColor.Yellow);
        }

        public void ShowBanner(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n=== {title.ToUpper()} ===");
            Console.ResetColor();
        }
        public void ShowProgress(string playerName, int magicBallsFound, int totalMagicBalls, int lives) 
        {
            Console.WriteLine($"\n=== Current Progress  of {playerName}===");
            Console.WriteLine($"Magic Balls Found: {magicBallsFound}/{totalMagicBalls}");
            Console.WriteLine($"Lives Remaining: {lives}");
            Console.WriteLine("=========================\n");
        }
        public void ShowGoodbyeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Thanks for playing! Goodbye!");
            Console.ResetColor();
        }
        public void ShowGameWinnMessage() 
        {
            Console.WriteLine(" ");
        }
        public void ClearScreen()
        {
            Console.Clear(); // Actual console clear operation
        }
    }
}
