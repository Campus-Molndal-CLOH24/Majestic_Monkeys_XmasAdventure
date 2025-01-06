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
        private CommandHandler? _commandHandler;

        [TestInitialize]
        public void Setup()
        {
            _mockRoomhandler = new Mock<IRoomhandler>();
            _mockMagicBallHandler = new Mock<IMagicBallHandler>();
            _mockGameActionHandler = new Mock<IGameActionHandler>();
            _mockRepository = new Mock<IgameRespository>();

            _commandHandler = new CommandHandler(
                _mockRoomhandler.Object,
                _mockMagicBallHandler.Object,
                _mockGameActionHandler.Object
            );
        }
        // test for start new game 
        //when the player name is entered and the game is saved also initialized as it should be 
        [TestMethod()]
        public void StartNewGame_ShouldInitializeGameStateAndSaveGame()
        {
            //arrange
            var gameState = new GameState();
            _mockRepository!.Setup(repo => repo.SaveGame(It.IsAny<GameState>()));

            //act
            //Capturing Console Input/Output and simulate user input and capture console output
            //effectively simulate and test console interactions without requiring actual user input or console output, making the test automated and repeatable.
            using (var input = new StringReader("TestPlayer"))
            using (var output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                _commandHandler!.StartNewGame(gameState, _mockRepository.Object);
            }

            //assert
            Assert.AreEqual("TestPlayer", gameState.PlayerName);
            Assert.IsNotNull(gameState.PlayerId);
            // Verify the SaveGame method was called
            _mockRepository.Verify(repo => repo.SaveGame(It.IsAny<GameState>()), Times.AtLeastOnce);
        }
        //Load game method 
        //scenario when the game is loaded successfully after user exits the game
        [TestMethod()]
        public void LoadGame_ShouldLoadSavedGameSuccessfully_WhenGameExists()
        {
            //arrange
            var gameState = new GameState { PlayerName = "TestPlayer" };
            var savedGame = new GameState
            {
                PlayerName = "TestPlayer",
                PlayerId = "1234",
                MagicBallsFound = 1,
                lives = 3,
                attemptsLeft = 5 // Mocked value
            };
            _mockRepository!.Setup(repo => repo.LoadGame("TestPlayer")).Returns(savedGame);

            using (var input = new StringReader("TestPlayer"))
            using (var output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                // Log the initial value of attemptsLeft
                Console.WriteLine($"Initial attemptsLeft: {gameState.attemptsLeft}");

                //act
                _commandHandler!.LoadGame(gameState, _mockRepository.Object);

                // Log the value of attemptsLeft after LoadGame
                Console.WriteLine($"After LoadGame attemptsLeft: {gameState.attemptsLeft}");

                //assert
                Assert.AreEqual("TestPlayer", gameState.PlayerName);
                Assert.AreEqual("1234", gameState.PlayerId);
                Assert.AreEqual(1, gameState.MagicBallsFound);
                Assert.AreEqual(3, gameState.lives);
                Assert.AreEqual(5, gameState.attemptsLeft);
                StringAssert.Contains(output.ToString(), "Game loaded successfully for player: TestPlayer");
            }
        }
        //scenario when the game is not found, and will thorw excenption
        [TestMethod()]
        public void LoadGame_ShouldFailGracefully_WhenNoSavedGameIsFound()
        {
            //arrange
            var gameState = new GameState
            {
                PlayerName = "UnknownPlayer",
                PlayerId = string.Empty
            };
            _mockRepository!.Setup(repo => repo.LoadGame("UnknownPlayer")).Returns((GameState?)null);

            using (var input = new StringReader("UnknownPlayer"))
            using (var output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);
                //act
                if (_commandHandler != null)
                {
                    _commandHandler.LoadGame(gameState, _mockRepository.Object);
                }
                //assert
                Assert.AreEqual("UnknownPlayer", gameState.PlayerName); // Or expected default value
                Assert.AreEqual(string.Empty, gameState.PlayerId);
                StringAssert.Contains(output.ToString(), "No saved game found for player name: UnknownPlayer");
            }
        }
    }
}