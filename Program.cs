﻿using Robot_Game_Freightliner.Interfaces.Games;
using Robot_Game_Freightliner.Models.Games;
using Robot_Game_Freightliner.Models.Games.RobotGame;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;
using System;

namespace Robot_Game_Freightliner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter instruction:");

            IGame game = new RobotBoardGame();
            game.SetupBoard(new Dimensions(3, 3));
            game.DisplayGame();

            while (true)
            {
                string userInput = Console.ReadLine().ToUpper();

                // Check if the user wants to quit
                if (userInput.ToUpper() == "STOP")
                {
                    break;
                }
                else
                {
                    game.OnInstruction(userInput);
                    game.DisplayGame();
                }
            }
        }
    }
}