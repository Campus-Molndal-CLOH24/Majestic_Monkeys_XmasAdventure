
using System.Runtime.InteropServices;
using Xmasgame.Logic;
using Xmasgame.UI;

namespace Xmasgame;

public static class Program
{
    public static void Main(string[] args)
    {
        GameEngine engine = new GameEngine();
        engine.Run(); // start game by first connect to game state
      
    }
}
