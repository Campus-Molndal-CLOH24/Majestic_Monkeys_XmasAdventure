using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Logic;
using Xmasgame.Data;
using Xmasgame.Models;
using Xmasgame.Interfaces;
using Xmasgame.UI;


namespace Xmasgame.UI
{
    public class MainMenu : IMainmenu
    {
        private readonly IGameDisplay _gamedisplay;
        private readonly IInputhandler _inputHandler;
        private readonly IgameRespository _repository;
        private readonly CommandHandler _commandHandler;

        public MainMenu(IGameDisplay gamedisplay, IInputhandler inputHandler, IgameRespository repository, CommandHandler commandHandler)
        {
            _gamedisplay = gamedisplay;
            _inputHandler = inputHandler;
            _repository = repository;
            _commandHandler = commandHandler;
        }

        public void DisplayEntryPoint()
        {
            _gamedisplay.ClearScreen();
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
            Console.WriteLine("4. View all saved games");
            Console.WriteLine("5. Exit");
        }
        //pass game state as parameter not DI naja 
        public void HandleMainMenu(GameState gamestate)
        {
            var running = true;
            while (running)
            {
                DisplayEntryPoint();
                Console.Write("Enter your choice (1-5) : ");
                var choice = _inputHandler.GetInput(); // Use the InputHandler to get input

                switch (choice)
                {
                    case "1":
                        _commandHandler.StartNewGame(gamestate, _repository);
                        break;
                    case "2":
                        _commandHandler.LoadGame(gamestate, _repository);
                        if (gamestate.PlayerId != null) // Only play if the game was loaded successfully
                        {
                            _commandHandler.PlayGame(gamestate, _repository);
                        }
                        break;
                    case "3":
                        ShowHelp(_gamedisplay);
                        break;
                    case "4":
                        ViewSavedGames();
                        break;
                    case "5":
                        Console.WriteLine("Thanks for playing! Goodbye!");
                        gamestate.IsQuitting = true;
                        Environment.Exit(0); //exit from the loop use running return false before but it did not work it, so user stuck on my game forever
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                
                if (running) // Only prompt for Enter if the loop will continue
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
        //facade pattern
        private void LoadGameMenu(GameState gameState)
        {
            var savedGames = _repository.GetAllSaveGames().ToList();

            if (!savedGames.Any())
            {
                _gamedisplay.ShowMessage("No saved games found.");
                return;
            }

            _gamedisplay.ShowMessage("Saved Games:");
            for (int i = 0; i < savedGames.Count; i++)
            {
                _gamedisplay.ShowMessage($"{i + 1}. Player: {savedGames[i].PlayerName}, Last Progress: {savedGames[i].MagicBallsFound}");
            }

            var choice = _inputHandler.GetRoomchoice(
                savedGames.Select((g, index) => $"Load Save {index + 1}").ToArray(), ()=>
                "Select a saved game to load:");

            var selectedGame = savedGames[choice];
            
            _gamedisplay.ShowMessage($"Loaded save for player {selectedGame.PlayerName}.");
        }
        private void ViewSavedGames()
        {
            var savedGames = _repository.GetAllSaveGames();

            if (!savedGames.Any())
            {
                _gamedisplay.ShowMessage("No saved games found.");
                return;
            }

            _gamedisplay.ShowMessage("Saved Games:");
            foreach (var game in savedGames)
            {
                _gamedisplay.ShowMessage($"Player: {game.PlayerName}, Progress: {game.MagicBallsFound} Magic Balls Found, Lives: {game.lives}");
            }
        }
        private void ShowHelp(IGameDisplay gamedisplay)
        {
            gamedisplay.ShowBanner("Help");
            gamedisplay.ShowMessage("1. Help Santa find the magic balls.\n2. Explore rooms, avoid Marcus, and collect all the magic balls.\n3. Use the menu to check progress or restart the game.\n4. Don't let Marcus steal your balls!", ConsoleColor.Yellow);
        }
    }
}
