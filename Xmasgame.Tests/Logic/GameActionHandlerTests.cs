using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Data;
using Moq;
using Xmasgame.Interfaces;
using Xmasgame.Models;

namespace Xmasgame.Logic.Tests
{
    [TestClass()]
    public class GameActionHandlerTests
    {

        //scenario: player wants tocontinuae the game and save game should not call this time
        [TestMethod()]
        public void HandleSaveOrQuit_Continue_ReturnsTrue()
        {
            // arrange
            var mockRepository = new Mock<IgameRespository>();
            Action<GameState> saveGameAction = gameState => mockRepository.Object.SaveGame(gameState);
            var GameActionHandler = new GameActionHandler(saveGameAction);
            
            //mock input provider to handle user input
            var mockInputProvider = new Mock<Func<string>>();
            mockInputProvider.SetupSequence(input => input())
                .Returns("C"); // Simulate user entering "C"

            var gameState = new GameState();
            
            // act
            var result = GameActionHandler.HandleSaveOrQuit(gameState, mockInputProvider.Object);

            // assert
            Assert.IsTrue(result, "Expected the method to return true when the user chooses to continue."); // show result 
            mockRepository.Verify(repo => repo.SaveGame(It.IsAny<GameState>()), Times.Never); // SaveGame should not be called

        }

        //scenario: player wants to save the game and save game should call this time
        [TestMethod()]
        public void HandleSaveOrQuit_SaveGame_SavesSuccessfully()
        {
            // arrange
            var mockRepository = new Mock<IgameRespository>();
            Action<GameState> saveGameAction = gameState => mockRepository.Object.SaveGame(gameState);
            var GameActionHandler = new GameActionHandler(saveGameAction);

            //mock input provider to handle user input
            var mockInputProvider = new Mock<Func<string>>();
            mockInputProvider.SetupSequence(input => input())
                .Returns("S") // Simulate user entering "S"
                .Returns("C");//then continue the game

            var gameState = new GameState();

            // act
            var result = GameActionHandler.HandleSaveOrQuit(gameState, mockInputProvider.Object);

            // assert
            Assert.IsTrue(result, "Expected the method to return true when the user chooses to save and continue game"); // show result 
            mockRepository.Verify(repo => repo.SaveGame(It.IsAny<GameState>()), Times.Once); // SaveGame should  be called

        }

        //scenario: player wants to quit the game  and succues to quit the game
        [TestMethod()]
        public void HandleSaveOrQuit_Quit_ReturnsFalse()
        {
            // arrange
            var mockRepository = new Mock<IgameRespository>();
            Action<GameState> saveGameAction = gameState => mockRepository.Object.SaveGame(gameState);
            var GameActionHandler = new GameActionHandler(saveGameAction);

            //mock input provider to handle user input
            var mockInputProvider = new Mock<Func<string>>();
            mockInputProvider.SetupSequence(input => input())
                .Returns("Q"); // Simulate user entering "Q"

            var gameState = new GameState();

            // act
            var result = GameActionHandler.HandleSaveOrQuit(gameState, mockInputProvider.Object);

            // assert
            Assert.IsFalse(result, "Expected the method to return false when the user chooses to quit.."); // show result 
            mockRepository.Verify(repo => repo.SaveGame(It.IsAny<GameState>()), Times.Never); // SaveGame should not be called

        }
        //scenario: player give input invalid input, show exception and then continue the game
        [TestMethod()]
        public void HandleSaveOrQuit_InvalidThenValidInput_ReturnsTrue()
        {
            // arrange
            var mockRepository = new Mock<IgameRespository>();
            Action<GameState> saveGameAction = gameState => mockRepository.Object.SaveGame(gameState);
            var GameActionHandler = new GameActionHandler(saveGameAction);

            //mock input provider to handle user input
            var mockInputProvider = new Mock<Func<string>>();
            mockInputProvider.SetupSequence(input => input())
                .Returns("INVALID") // First invalid input
                .Returns("C"); // Then continue the game

            var gameState = new GameState();

            // act
           bool result = false;
            try
            {
                result = GameActionHandler.HandleSaveOrQuit(gameState, mockInputProvider.Object);
            }
            catch (ArgumentException ex)
            {
                // Handle the exception and provide the valid input
                result = GameActionHandler.HandleSaveOrQuit(gameState, mockInputProvider.Object);
            }

            // assert
            Assert.IsTrue(result, "Expected the method to return true after the user enters a valid input (C) after an invalid input."); // show result 
            mockRepository.Verify(repo => repo.SaveGame(It.IsAny<GameState>()), Times.Never); // SaveGame should not be called

        }
    }
}