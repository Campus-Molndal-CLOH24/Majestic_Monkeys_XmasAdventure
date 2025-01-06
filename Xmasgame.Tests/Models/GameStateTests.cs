using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.Models.Tests
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod]
        public void Reset_ShouldSetSpecificFieldsToDefaults()
        {
            // Arrange
            var gameState = new GameState
            {
                MagicBallsFound = 2,
                lives = 1,
                totalMagicBalls = 5
            };

            // Act
            gameState.Reset();

            // Assert
            Assert.AreEqual(0, gameState.MagicBallsFound, "MagicBallsFound should reset to 0.");
            Assert.AreEqual(3, gameState.lives, "Lives should reset to the default value.");
            Assert.AreEqual(3, gameState.totalMagicBalls, "TotalMagicBalls should reset to the default value.");
        }
    }
}
