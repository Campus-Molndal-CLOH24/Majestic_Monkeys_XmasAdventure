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
        private readonly GameState _gamestate = new GameState();
        
        
        public void Run() 
        {
            
            while (true) 
            {
                MainMenu.HandleMainMenu(_gamestate); // pass game state as parameter to use game state and start game. 
            }
        }
    }
}
