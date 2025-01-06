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
        private const int DefaultLives = 3;
        private const int DefaultTotalMagicBalls = 3;
        private const int DefaultAttemptsLeft = 10;

        public string PlayerId { get; set; } = string.Empty;
        public string? PlayerName { get; set; } = string.Empty;
        public int MagicBallsFound { get; set; } = 0;
        public int lives { get; set; } = DefaultLives;
        public int totalMagicBalls { get; set; } = DefaultTotalMagicBalls;
        public int attemptsLeft { get; set; } = DefaultAttemptsLeft;
        public bool IsQuitting { get; set; } = false;

        public void Reset()
        {
            MagicBallsFound = 0;
            lives = DefaultLives;
            totalMagicBalls = DefaultTotalMagicBalls;
           
        }
    }
}
