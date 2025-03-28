﻿using System;
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
        //private readonly CommandHandler _commandHandler;
        private readonly IMainmenu _mainmenu;

        public GameEngine(GameState gameState, IGameDisplay display, IInputhandler inputHandler, IRoomhandler roomHandler, IMagicBallHandler magicBallHandler, IGameActionHandler gameActionHandler, IgameRespository repository, IMainmenu mainMenu)
        {
            this._gameState = gameState;
            this._display = display;
            this._inputHandler = inputHandler;
            this._roomHandler = roomHandler;
            this._magicBallHandler = magicBallHandler;
            this._gameActionHandler = gameActionHandler;
            this._repository = repository;
            this._mainmenu = mainMenu;

            var _commandHandler = new CommandHandler(_roomHandler, _magicBallHandler, _gameActionHandler, repository, inputHandler); //use depency injection to pass the handler to command handler
            _mainmenu = new MainMenu(display, inputHandler, repository, _commandHandler);

        }

        public void Run()
        {
            
            if (_gameState.IsQuitting)
            {
                _display.ShowGoodbyeMessage();
                return; // Exit immediately if the game is set to quit
            }
            //bool isRunning = true;
            // Game loop
            while (!_gameState.IsQuitting) // Continue running until the user quits
            {
                _mainmenu.HandleMainMenu(_gameState); // Handle main menu and options

                if (_gameState.IsQuitting) // Check if the user chose to quit
                {
                    _display.ShowGoodbyeMessage();
                    return; // Exit the Run() method entirely
                }

            }
        }
    }
}
