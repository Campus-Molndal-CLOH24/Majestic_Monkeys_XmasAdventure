
using System.Runtime.InteropServices;
using Xmasgame.Data;
using Xmasgame.Interfaces;
using Xmasgame.Logic;
using Xmasgame.Models;
using Xmasgame.UI;

namespace Xmasgame;

public static class Program
{
    public static void Main(string[] args)
    {
        IGameDisplay display = new GameDisplay();
        IInputhandler inputHandler = new InputHandler(); // Ensure this class exists and implements IInputHandler
        IgameRespository repository = new LiteDbGameRepository();

        IMagicBallHandler magicBallHandler = new MagicballHandler();
        IGameActionHandler gameActionHandler = new GameActionHandler(repository.SaveGame);
        IRoomhandler roomHandler = new RoomHandler(inputHandler);

        CommandHandler commandHandler = new CommandHandler(roomHandler, magicBallHandler, gameActionHandler);

        GameState gameState = new GameState(); // get reslove from pilot 
        GameEngine engine = new GameEngine(gameState,display, inputHandler, roomHandler, magicBallHandler, gameActionHandler, repository);

        engine.Run(); // Start the game loop

    }
}
