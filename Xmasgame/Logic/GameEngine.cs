using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Models;
using Xmasgame.UI;
using Xmasgame.Interfaces;
using Xmasgame.Data;
// this class run game loop from mainmenu and alsi delagate task to command handler and update to game statge
namespace Xmasgame.Logic
{
    public class GameEngine : IGameEngine
    {
        private readonly GameState _gameState;
        private readonly IGameDisplay _display;
        private readonly IInputhandler _inputHandler;
        private readonly IRoomhandler _roomHandler;
        private readonly IMagicBallHandler _magicBallHandler;
        private readonly IGameActionHandler _gameActionHandler;
        private readonly IgameRespository _repository;
        private readonly CommandHandler _commandHandler;
        private readonly MainMenu _mainmenu;

        public GameEngine(GameState gameState, IGameDisplay display, IInputhandler inputHandler, IRoomhandler roomHandler, IMagicBallHandler magicBallHandler, IGameActionHandler gameActionHandler, IgameRespository repository)
        {
            _gameState = gameState;
            _display = display;
            _inputHandler = inputHandler;
            _roomHandler = roomHandler;
            _magicBallHandler = magicBallHandler;
            _gameActionHandler = gameActionHandler;
            _repository = repository;

            _gameState = new GameState();
            _mainmenu = new MainMenu(display, inputHandler, repository);
            _commandHandler = new CommandHandler(_roomHandler, _magicBallHandler, _gameActionHandler); //use depency injection to pass the handler to command handler
        }

        public void Run() 
        {
            
            while (true) 
            {
                _mainmenu.HandleMainMenu(_gameState); // pass game state as parameter to use game state and start game. 
            }
        }
    }
}
