using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.UI;
using Xmasgame.Data;


namespace Xmasgame.Logic
{
    public static class CommandHandler
    {
        public static void StartNewGame(GameState gameState) // create new game ? 
        {
            Console.WriteLine("Starting a new game .....");
            Console.WriteLine("What is your name?");
            gameState.PlayerName = Console.ReadLine();
            gameState.Reset();
            Console.WriteLine($"Welcome, {gameState.PlayerName}! Let’s start the adventure.");

            PlayGame(gameState);

        }
        //load game method
        public static void LoadGame(GameState gameState)
        {
            Console.WriteLine("Resumimg your Game ......... ");
            System.Console.WriteLine("Welcome back, " + gameState.PlayerName + "!");
            PlayGame(gameState);

        }
        // play game method
        public static void PlayGame(GameState gameState)
        {
            while (gameState.attemptsLeft > 0 && gameState.lives > 0)
            {

                RoomHandler.HandlerRoomChoice(gameState);
                MagicballHandler.SearchMagicBalls(gameState);
                gameState.attemptsLeft--;

                Console.WriteLine($"\nAttempts Left: {gameState.attemptsLeft}, Lives: {gameState.lives}");

                if (!GameActionHandler.HandleSaveOrQuit(gameState))
                {
                    break;
                }

                if (gameState.MagicBallsFound >= gameState.totalMagicBalls)
                {
                    Console.WriteLine("Congratulations! You've saved Christmas!");
                    break;
                }
            }
            if (gameState.attemptsLeft <= 0)
            {
                Console.WriteLine("You're out of attempts. Game Over!");
            }
        }
        // save game method
        public static void SaveGame(GameState gameState)
        {
            Console.WriteLine("Saving Game ......... ");
        }
        //playerName, int magicBallsFound, int totalMagicBalls, int lives, int attemptsLeft
        public static void ShowGameProgress(GameState gameState)
        {
            GameDisplay.ShowProgress(
                gameState.PlayerName,
                gameState.MagicBallsFound,
                gameState.totalMagicBalls,
                gameState.lives
                );
        }
    }
}
