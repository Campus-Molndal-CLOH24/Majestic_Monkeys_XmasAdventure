using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xmasgame.Interfaces;
using Xmasgame.Models;
using Xmasgame.Data;
using Xmasgame.UI;

namespace Xmasgame.Logic.Tests
{
    [TestClass()]
    public class GameEngineTests
    {
        private Mock<IGameDisplay> mockDisplay;
        private Mock<IInputhandler> mockInputHandler;
        private Mock<IRoomhandler> mockRoomHandler;
        private Mock<IMagicBallHandler> mockMagicBallHandler;
        private Mock<IGameActionHandler> mockGameActionHandler;
        private Mock<IgameRespository> mockRepository;
        private Mock<IMainmenu> mockMainmenu;
        private GameState gameState;
        private GameEngine gameEngine;
        

        [TestInitialize]
        public void Setup()
        {
            // Arrange common dependencies
            mockDisplay = new Mock<IGameDisplay>();
            mockInputHandler = new Mock<IInputhandler>();
            mockRoomHandler = new Mock<IRoomhandler>();
            mockMagicBallHandler = new Mock<IMagicBallHandler>();
            mockGameActionHandler = new Mock<IGameActionHandler>();
            mockRepository = new Mock<IgameRespository>();
            mockMainmenu = new Mock<IMainmenu>();
            

        }
        //scenario  : User quits immediately and shows goodbye
        //Checks if the game stops when IsQuitting is true from the start.
        [TestMethod()]
        public void Run_UserQuitsImmediately_ShowsGoodbyeMessage()
        {
            // Arrange
            gameState = new GameState { IsQuitting = true }; // simulate user quitting

            gameEngine = new GameEngine(gameState, mockDisplay.Object, mockInputHandler.Object, mockRoomHandler.Object, mockMagicBallHandler.Object, mockGameActionHandler.Object, mockRepository.Object, mockMainmenu.Object);
            // Act
            gameEngine.Run();

            // Assert
            mockDisplay.Verify(display => display.ShowGoodbyeMessage(), Times.Once);
        }

        [TestMethod()]
        public void Run_ValidInput_MainMenuHandlesInputCorrectly()
        {
            // Arrange
            gameState = new GameState();
            mockInputHandler.Setup(input => input.GetInput()).Returns("1"); // Simulate valid input

            gameEngine = new GameEngine(gameState, mockDisplay.Object, mockInputHandler.Object, mockRoomHandler.Object, mockMagicBallHandler.Object, mockGameActionHandler.Object, mockRepository.Object, mockMainmenu.Object);

            // Act
            gameEngine.Run();

            // Assert
            mockInputHandler.Verify(input => input.GetInput(), Times.AtLeastOnce);
        }


    }
}