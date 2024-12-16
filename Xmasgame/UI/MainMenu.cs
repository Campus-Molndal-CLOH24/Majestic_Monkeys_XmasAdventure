﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.UI
{
    public static class MainMenu
    {
        public static void DisplayEntryPoint()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green; // Set color to green
            Console.WriteLine("         *         ");
            Console.WriteLine("        ***        ");
            Console.WriteLine("       *****       ");
            Console.WriteLine("      *******      ");
            Console.WriteLine("     *********     ");
            Console.WriteLine("    ***********    ");
            Console.WriteLine("   *************   ");
            Console.WriteLine("        ***        ");
            Console.WriteLine("       *****       ");
            Console.WriteLine("      *******      ");
            Console.WriteLine("     *********     ");
            Console.ResetColor(); // Reset to default color
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set color for trunk
            Console.WriteLine("        | |        ");
            Console.WriteLine("        | |        ");
            Console.ResetColor();
            // Menu Title and Options
            Console.ForegroundColor = ConsoleColor.Cyan; // Set color to cyan for the menu title
            Console.WriteLine("\n=== 🎄 Welcome To Santa's Magic Ball Hunt 🎄 ===");
            Console.ResetColor();
            
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. I Need Help !!!!!!!!! ");
            Console.WriteLine("4. Exit");
        }

        public static void HandleMainMenu()
        {
            var running = true;
            while (running)
            {
                DisplayEntryPoint();
                Console.Write("Enter your choice (1-4) : ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartNewGame();
                        break;
                    case "2":
                        LoadGame();
                        break;
                    case "3":
                        ShowHelp();
                        break;
                    case "4":
                        Console.WriteLine("Thanks for playing! Goodbye!");
                        running = false; //exit from the loop 
                        break;
                    default:
                        Console.WriteLine("Hello --- Wrong choice!");
                        break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        public static void StartNewGame()
        {
            Console.WriteLine("Starting a new game .....");
        }
        public static void LoadGame()
        {
            Console.WriteLine("Loading Game ......... ");
        }
        public static void ShowHelp()
        {
            Console.WriteLine("\n=== Help ===");
            Console.WriteLine("1. In this game, you help Santa find magic balls.");
            Console.WriteLine("2. Explore rooms, avoid Marcus, and collect all the magic balls.");
            Console.WriteLine("3. Use the menu to check progress or restart the game.");
            Console.WriteLine("4. Don't let Marcus steal your lives or attempts!");
        }
    }
}
