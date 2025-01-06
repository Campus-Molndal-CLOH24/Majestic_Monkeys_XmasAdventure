using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Models
{
    // set all before players starts game also add reset method to reset everytime when they create new game
    public class GameState
    {
        public string PlayerId { get; set; } = " ";
        public string? PlayerName { get; set; } = " ";
        public int MagicBallsFound { get; set; } = 0;
        public int lives { get; set; } = 3;
        public int totalMagicBalls { get; set; } = 3;
        public int attemptsLeft { get; set; } = 10;
        public bool IsQuitting { get; set; } = false;

        public void Reset()
        {
            MagicBallsFound = 0;
            lives = 4;
            totalMagicBalls = 3;
            
        }
    }
}
