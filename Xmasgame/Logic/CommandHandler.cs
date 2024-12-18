using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.UI;


namespace Xmasgame.Logic
{
    public class CommandHandler
    {
        public static void StartNewGame(GameState gameState) // create new game ? 
        {
            Console.WriteLine("Starting a new game .....");
            Console.WriteLine("What is your name?");
            gameState.PlayerName = Console.ReadLine();
            gameState.Reset();
            Console.WriteLine($"Welcome, {gameState.PlayerName}! Let’s start the adventure.");
            ShowGameProgress(gameState);
        }
        public static void LoadGame(GameState gameState)
        {
            Console.WriteLine("Loading Game ......... ");
             
        }

        public static void GetRoomchoice(GameState gameState) 
        {
            string[] rooms = { "Living Room", "Toy Workshop", "Snowy Forest" };
            int chosenRoom = InputHandler.GetRoomchoice(rooms);

            Console.WriteLine($"You are entering the {rooms[chosenRoom]}...");
            // add references methos from playes whrn plyers got into the rooms that found something they colud keep it like balls or cookiess
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
