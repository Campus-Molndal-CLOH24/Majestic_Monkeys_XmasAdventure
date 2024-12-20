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

                GetRoomchoice(gameState);
                SearchMagicBalls(gameState);
                gameState.attemptsLeft--;

                Console.WriteLine($"\nAttempts Left: {gameState.attemptsLeft}, Lives: {gameState.lives}");

                Console.WriteLine("\nDo you want to (C)ontinue, (S)ave, or (Q)uit?");
                string choice = Console.ReadLine()?.ToUpper();

                if (choice == "S")
                {
                    SaveGame(gameState);
                    Console.WriteLine("Game saved. Do you want to (C)ontinue or (Q)uit?");
                    choice = Console.ReadLine()?.ToUpper();
                    if (choice == "Q")
                    {
                        Console.WriteLine("Quitting game. See you next time!");
                        break;
                    }
                }
                else if (choice == "Q")
                {
                    Console.WriteLine("Quitting game. See you next time!");
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

        public static void GetRoomchoice(GameState gameState)
        {
            List<Rooms> rooms = new List<Rooms>
            {
                new Livingroom(),
                new ToyWorkshop(),
                new SnowyForest()
            };
            // Extract room names to pass to InputHandler
            string[] roomsNames = rooms.Select(r => r.RoomsName!).ToArray();
            //call Inputhandle to get user choice by index 
            int chosenRoom = InputHandler.GetRoomchoice(roomsNames);
            //Acces the chosen room and show detail
            Rooms Getrooms = rooms[chosenRoom];
            Console.WriteLine($"\nYou are entering the {Getrooms.RoomsName}...");
            Console.WriteLine(Getrooms.RoomsDescription);

            // Display items in the room (if any)
            if (Getrooms.Items != null && Getrooms.Items.Any())
            {
                System.Console.WriteLine();
                Console.WriteLine("You see the following items:");
                foreach (var item in Getrooms.Items)
                {
                    Console.WriteLine($" {item.ItemName} - {item.Description}");
                }
            }
            else
            {
                Console.WriteLine("There are no items in this room.");
            }
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
        // search balls 
        public static void SearchMagicBalls(GameState gameState)
        {
            Random random = new Random(); // call randon method
            int result = random.Next(0, 101);//1-50
            if (result <= 40)
            {
                gameState.MagicBallsFound++;
                Console.WriteLine("You found a magic ball!");
            }
            else if (result <= 70)
            {
                Console.WriteLine("Oh Nooooo, Marcus has set a trap!");
                EnconterMarcus(gameState);
            }
            else
            {
                gameState.lives++;
                Console.WriteLine("You get help from Elf !! , now you gain extra life");
            }
            if (gameState.MagicBallsFound >= gameState.totalMagicBalls)
            {
                Console.WriteLine("Congratulations! You've found all the magic balls and saved Christmas!");
            }
        }

        //enconter The evil Marcus 
        public static void EnconterMarcus(GameState gameState)
        {
            Console.WriteLine("MWAHAHAHA! Marcus challenges you with a riddle... ");
            Console.WriteLine("What has to be broken before you can use it?");
            string answer = Console.ReadLine()?.ToLower();

            if (answer == "egg")
            {

                Console.WriteLine("Correct! You escape Marcus's trap.");
            }
            else
            {
                gameState.lives--;
                Console.WriteLine("Wrong answer! You lose a life. Lives remaining: " + gameState.lives);

                if (gameState.lives <= 0)
                {
                    Console.WriteLine("You have run out of lives. Game Over!");
                    Environment.Exit(0); // exit loop when you are die!! 
                }
            }
        }


    }
}
