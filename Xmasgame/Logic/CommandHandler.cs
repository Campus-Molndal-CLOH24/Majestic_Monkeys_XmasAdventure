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
            gameState.PlayerId = Guid.NewGuid().ToString().Substring(0,4);
            gameState.Reset();
            repository.SaveGame(gameState);
            Console.WriteLine($"Welcome, {gameState.PlayerName}! Let’s start the adventure.");

            PlayGame(gameState, repository);

        }
        //load game method
        public void LoadGame(GameState gameState, IgameRespository repository)
        {
            Console.WriteLine("Enter your  Name to load your saved game:");
            string PlayerName = Console.ReadLine();
            try
            {
                var loadedGame = repository.LoadGame(PlayerName);
                if (loadedGame != null)
                {
                    
                    gameState.PlayerId = loadedGame.PlayerId;
                    gameState.PlayerName = loadedGame.PlayerName;
                    gameState.MagicBallsFound = loadedGame.MagicBallsFound;
                    gameState.lives = loadedGame.lives;
                    gameState.attemptsLeft = loadedGame.attemptsLeft;
                    Console.WriteLine($"Game loaded successfully for player: {gameState.PlayerName}");
                    Console.WriteLine($"Game loaded successfully. PlayerId: {gameState.PlayerId}");


                }
                else 
                {
                    Console.WriteLine($"No saved game found for player name: {PlayerName}");
                    return;
                }
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
            while (gameState.attemptsLeft > 0 && gameState.lives > 0 && !gameState.IsQuitting)
            {

                _roomhandler.HandlerRoomChoice(gameState);
                _magicballhandler.SearchMagicBalls(gameState);
                

                Console.WriteLine($"\nAttempts Left: {gameState.attemptsLeft}, Lives: {gameState.lives}");

                if (!_gameActionHandler.HandleSaveOrQuit(gameState, () => Console.ReadLine() ?? string.Empty))
                {
                    repository.SaveGame(gameState);
                    gameState.IsQuitting = true;
                    break;
                }
                // Decrease attempts only after the player has completed their turn
                gameState.attemptsLeft--;

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
            if (gameState.IsQuitting)
            {
                
                return; // Exit the Run() method
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
