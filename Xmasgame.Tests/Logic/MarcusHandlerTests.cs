using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Models;
using Moq;
using Xmasgame.Interfaces;

namespace Xmasgame.Logic.Tests
{
    [TestClass()]
    public class MarcusHandlerTests
    {
        
        private GameState _gameState;
        private Mock<IInputhandler> mockInputHandler;

        [TestInitialize]
        public void Setup()
        {
            mockInputHandler = new Mock<IInputhandler>();
            _gameState = new GameState 
            {
                lives = 3 // Start with 3 lives
            };
        }
        [TestMethod()]
        public void EnconterMarcus_CorrectAnswer_EscapesTrap()
        {
            // Arrange
            mockInputHandler.Setup(i => i.GetInput()).Returns("egg");

            // Act
            MarcusHandler.EnconterMarcus(_gameState, mockInputHandler.Object);

            // Assert
            
            Assert.AreEqual(3, _gameState.lives, "Lives should remain unchanged with the correct answer.");
        }

        [TestMethod()]
        public void EnconterMarcus_WrongAnswer_LosesLife()
        {
            // Arrange
            mockInputHandler.Setup(i => i.GetInput()).Returns("wrong answer");

            // Act
            MarcusHandler.EnconterMarcus(_gameState, mockInputHandler.Object);

            // Assert
            Assert.AreEqual(2, _gameState.lives, "Player should lose a life with the wrong answer.");
        }
    }
    
}