using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Models;
using System.Reflection.Metadata;
using Xmasgame.Interfaces;

namespace Xmasgame.Logic.Tests
{
    [TestClass()]
    public class MagicballHandlerTests
    {
        
        private GameState _gameState;

        [TestInitialize]
        public void Setup()
        {
            
            _gameState = new GameState
            {
                MagicBallsFound = 0,
                lives = 3,
                totalMagicBalls = 3,
            };
        }

        [TestMethod()]
        public void SearchMagicBalls_FindsMagicBall_IncrementsMagicBallsFound()
        {
            /// Arrange: Use the interface
            IMagicBallHandler handler = new MagicballHandler();
            _gameState.MagicBallsFound = 0;

            // Act: Pass a specific value that falls in the "magic ball found" range
            handler.SearchMagicBalls(_gameState, randomValue: 30);

            // Assert
            Assert.AreEqual(1, _gameState.MagicBallsFound, "MagicBallsFound should increment by 1.");
        }

        [TestMethod]
        public void SearchMagicBalls_ElfHelps_IncrementsLives()
        {
            // Arrange: Use the interface
            IMagicBallHandler handler = new MagicballHandler();
            int initialLives = _gameState.lives;

            // Act: Pass a specific value that triggers "Elf helps"
            handler.SearchMagicBalls(_gameState, randomValue: 80);

            // Assert
            Assert.AreEqual(initialLives + 1, _gameState.lives, "Lives should increase when Elf helps.");
        }
    }
}