using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Interfaces
{
    public interface IGameDisplay
    {
        void ShowMessage(string message, ConsoleColor color = ConsoleColor.White);
        void ShowWarning(string warning);
        void ShowBanner(string title);
        void ShowProgress(string playerName, int magicBallsFound, int totalMagicBalls, int lives);
        void ShowGoodbyeMessage();
        void ClearScreen();
    }
}

