using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.UI;
// this class run game loop from mainmenu and alsi delagate task to command handler and update to game statge
namespace Xmasgame.Logic
{
    public class GameEngine
    {
        public void Run() 
        {
            bool runnning = true;
            while (runnning) 
            {
                MainMenu.HandleMainMenu();
            }
        }
    }
}
