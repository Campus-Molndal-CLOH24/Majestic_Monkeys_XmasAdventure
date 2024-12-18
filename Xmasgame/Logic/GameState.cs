using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Logic
{
    // set all before players starts game also add reset method to reset everytime when they create new game
    public class GameState
    {
        public string PlayerName { get; set; }
        public int MagicmagicBallsFound { get; set; } = 0;
        public int lives { get; set; } = 3;
        public int attemptsLeft { get; set; } = 5;

        public void Reset() 
        {
            MagicmagicBallsFound = 0;
            lives = 0;
            attemptsLeft = 0;
        } 
    }
}
