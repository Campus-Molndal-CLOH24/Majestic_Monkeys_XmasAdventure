using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Models;

namespace Xmasgame.Data.Tests
{
    [TestClass()]
    public class LiteDbGameRepositoryTests
    {
        private LiteDbGameRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            // Initialize repository (use a unique path to avoid overwriting your real data)
            _repository = new LiteDbGameRepository();
        }

        [TestMethod]
        public void SaveGame_Should_Save_GameState()
        {
            // Arrange
            var gameState = new GameState
            {
                PlayerId = "test123",
                PlayerName = "TestPlayer",
                lives = 5,
                attemptsLeft = 10
            };

            // Act
            _repository.SaveGame(gameState);

            // Assert
            var savedGame = _repository.LoadGame("TestPlayer");
            Assert.IsNotNull(savedGame, "Game should be saved successfully.");
            Assert.AreEqual("TestPlayer", savedGame.PlayerName);
            Assert.AreEqual(5, savedGame.lives);
            Assert.AreEqual(10, savedGame.attemptsLeft);
        }

        [TestMethod]
        public void LoadGame_Should_Return_Correct_GameState()
        {
            // Arrange
            var gameState = new GameState
            {
                PlayerId = "load123",
                PlayerName = "LoadTestPlayer",
                lives = 3,
                attemptsLeft = 7
            };

            _repository.SaveGame(gameState);

            // Act
            var loadedGame = _repository.LoadGame("LoadTestPlayer");

            // Assert
            Assert.IsNotNull(loadedGame, "Game should load successfully.");
            Assert.AreEqual("LoadTestPlayer", loadedGame.PlayerName);
            Assert.AreEqual(3, loadedGame.lives);
            Assert.AreEqual(7, loadedGame.attemptsLeft);
        }

        [TestMethod]
        public void GetAllSaveGames_Should_Return_All_SavedGames()
        {
            // Arrange
            _repository.SaveGame(new GameState { PlayerId = "p1", PlayerName = "Player1", lives = 3, attemptsLeft = 5 });
            _repository.SaveGame(new GameState { PlayerId = "p2", PlayerName = "Player2", lives = 4, attemptsLeft = 6 });

            // Act
            var allGames = _repository.GetAllSaveGames();

            // Assert
            Assert.IsNotNull(allGames, "Game list should not be null.");
            Assert.IsTrue(allGames.Any(g => g.PlayerName == "Player1"), "Player1 should exist in saved games.");
            Assert.IsTrue(allGames.Any(g => g.PlayerName == "Player2"), "Player2 should exist in saved games.");
        }
    }
}