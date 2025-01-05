using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.UI;
using Xmasgame.Data;
using Xmasgame.Models;
using Xmasgame.Logic;
using Xmasgame.Interfaces;


namespace Xmasgame.Logic
{
    public  class CommandHandler
    {
        private readonly IRoomhandler _roomhandler;
        private readonly IMagicBallHandler _magicballhandler;
        private readonly IGameActionHandler _gameActionHandler;
        public CommandHandler(IRoomhandler roomhandler, IMagicBallHandler magicballhandler, IGameActionHandler gameActionHandler)
        {
            _roomhandler = roomhandler;
            _magicballhandler = magicballhandler;
            _gameActionHandler = gameActionHandler;
        }
        
        // start new game method
        public void StartNewGame(GameState gameState, IgameRespository repository) // create new game  and save it
        {
            Console.WriteLine("Starting a new game .....");
            Console.WriteLine("What is your name?");
            gameState.PlayerName = Console.ReadLine();
            gameState.PlayerId = Guid.NewGuid().ToString();
            gameState.Reset();
            repository.SaveGame(gameState);
            Console.WriteLine($"Welcome, {gameState.PlayerName}! Let’s start the adventure.");

            PlayGame(gameState, repository);

        }
        //load game method
        public void LoadGame(GameState gameState, IgameRespository repository)
        {
            Console.WriteLine("Enter your PLayer Id to load your saved game:");
            string playerId = Console.ReadLine();
            try
            {
                var loadedGame = repository.LoadGame(playerId);
                if (loadedGame == null)
                {
                    Console.WriteLine("No saved game found for the given Player Id.");
                    return;
                }
                gameState.PlayerName = loadedGame.PlayerName;
                gameState.MagicBallsFound = loadedGame.MagicBallsFound;
                gameState.lives = loadedGame.lives;
                gameState.attemptsLeft = loadedGame.attemptsLeft;
                Console.WriteLine("Game loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game: {ex.Message}");
            }
            PlayGame(gameState, repository);

        }
        // play game method
        public  void PlayGame(GameState gameState, IgameRespository repository)
        {
            while (gameState.attemptsLeft > 0 && gameState.lives > 0)
            {

                _roomhandler.HandlerRoomChoice(gameState);
                _magicballhandler.SearchMagicBalls(gameState);
                gameState.attemptsLeft--;

                Console.WriteLine($"\nAttempts Left: {gameState.attemptsLeft}, Lives: {gameState.lives}");

                if (!_gameActionHandler.HandleSaveOrQuit(gameState))
                {
                    repository.SaveGame(gameState);
                    break;
                }

                if (gameState.MagicBallsFound >= gameState.totalMagicBalls)
                {
                    Console.WriteLine("Congratulations! You've saved Christmas!");
                    repository.SaveGame(gameState);
                    break;
                }
            }
            if (gameState.attemptsLeft <= 0)
            {
                Console.WriteLine("You're out of attempts. Game Over!");
                repository.SaveGame(gameState);
            }
        }
        // save game method
        public void SaveGame(GameState gameState)
        {
            SaveGame(gameState); // Example save logic
            Console.WriteLine("Game saved!");
        }
    }
}
