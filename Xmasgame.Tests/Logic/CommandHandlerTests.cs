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
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Xmasgame.Logic.Tests
{
    [TestClass()]
    public class CommandHandlerTests
    {
        private Mock<IRoomhandler>? _mockRoomhandler;
        private Mock<IMagicBallHandler>? _mockMagicBallHandler;
        private Mock<IGameActionHandler>? _mockGameActionHandler;
        private Mock<IgameRespository>? _mockRepository;
        private readonly Mock<IInputhandler> mockInputHandler = new Mock<IInputhandler>();
        private CommandHandler? _commandHandler;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks for dependencies
            _mockRoomhandler = new Mock<IRoomhandler>();
            _mockMagicBallHandler = new Mock<IMagicBallHandler>();
            _mockGameActionHandler = new Mock<IGameActionHandler>();
            _mockRepository = new Mock<IgameRespository>();

            // Initialize the CommandHandler with mocked dependencies
            _commandHandler = new CommandHandler(
                _mockRoomhandler.Object,
                _mockMagicBallHandler.Object,
                _mockGameActionHandler.Object
            );
        }

        [TestMethod()]
        public void StartNewGame_ShouldInitializeGameStateAndSaveGame()
        {
            // Arrange
            var gameState = new GameState();
            // Setup the repository mock to expect a SaveGame call
            _mockRepository!.Setup(repo => repo.SaveGame(It.IsAny<GameState>()));
            // Setup the input handler mock to return "TestPlayer" when GetInput is called
            mockInputHandler.Setup(input => input.GetInput()).Returns("TestPlayer");

            // Act
            using (var output = new StringWriter())
            {
                Console.SetOut(output);

                // Call the StartNewGame method
                _commandHandler!.StartNewGame(gameState, _mockRepository.Object, mockInputHandler.Object);
            }

            // Assert
            // Verify that the game state is initialized correctly
            Assert.AreEqual("TestPlayer", gameState.PlayerName);
            Assert.IsNotNull(gameState.PlayerId);
            // Verify that the SaveGame method was called at least once
            _mockRepository.Verify(repo => repo.SaveGame(It.IsAny<GameState>()), Times.AtLeastOnce);
        }

        [TestMethod()]
        public void LoadGame_ShouldLoadSavedGameSuccessfully_WhenGameExists()
        {
            // Arrange
            var gameState = new GameState { PlayerName = "TestPlayer" };
            var savedGame = new GameState
            {
                PlayerName = "TestPlayer",
                PlayerId = "1234",
                MagicBallsFound = 1,
                lives = 3,
                attemptsLeft = 5
            };
            // Setup the repository mock to return the saved game when LoadGame is called
            _mockRepository!.Setup(repo => repo.LoadGame("TestPlayer")).Returns(savedGame);
            // Setup the input handler mock to return "TestPlayer" when GetInput is called
            mockInputHandler.Setup(input => input.GetInput()).Returns("TestPlayer");

            using (var output = new StringWriter())
            {
                Console.SetOut(output);

                // Act
                // Call the LoadGame method
                _commandHandler!.LoadGame(gameState, _mockRepository.Object, mockInputHandler.Object);

                // Assert
                // Verify that the game state is loaded correctly
                Assert.AreEqual("TestPlayer", gameState.PlayerName);
                Assert.AreEqual("1234", gameState.PlayerId);
                Assert.AreEqual(1, gameState.MagicBallsFound);
                Assert.AreEqual(3, gameState.lives);
                Assert.AreEqual(5, gameState.attemptsLeft);
                // Verify that the output contains the success message
                StringAssert.Contains(output.ToString(), "Game loaded successfully for player: TestPlayer");
            }
        }

        [TestMethod()]
        public void LoadGame_ShouldFailGracefully_WhenNoSavedGameIsFound()
        {
            // Arrange
            var gameState = new GameState
            {
                PlayerName = "UnknownPlayer",
                PlayerId = string.Empty
            };
            // Setup the repository mock to return null when LoadGame is called with "UnknownPlayer"
            _mockRepository!.Setup(repo => repo.LoadGame("UnknownPlayer")).Returns((GameState?)null);
            // Setup the input handler mock to return "UnknownPlayer" when GetInput is called
            mockInputHandler.Setup(input => input.GetInput()).Returns("UnknownPlayer");

            using (var output = new StringWriter())
            {
                Console.SetOut(output);

                // Act
                // Call the LoadGame method
                _commandHandler!.LoadGame(gameState, _mockRepository.Object, mockInputHandler.Object);

                // Assert
                // Verify that the game state remains unchanged
                Assert.AreEqual("UnknownPlayer", gameState.PlayerName);
                Assert.AreEqual(string.Empty, gameState.PlayerId);
                // Verify that the output contains the failure message
                StringAssert.Contains(output.ToString(), "No saved game found for player name: UnknownPlayer");
            }
        }
    }
}