using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Interfaces;
using Xmasgame.Models;

namespace Xmasgame.Logic
{
    public static class MarcusHandler
    {
        public static void EnconterMarcus(GameState gameState, IInputhandler inputhandler)
        {
            Console.WriteLine("MWAHAHAHA! Marcus challenges you with a riddle... ");
            Console.WriteLine("What has to be broken before you can use it?");
            string answer = inputhandler.GetInput().ToLower();

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
