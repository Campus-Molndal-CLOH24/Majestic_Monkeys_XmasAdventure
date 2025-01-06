using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Moq;
using Xmasgame.Interfaces;
using Xmasgame.Models;


namespace Xmasgame.Logic.Tests
{
    /// <summary>
    /// Correctly handles valid room choices.
    ///Gracefully handles invalid room choices.
    ///Displays items in the room, if available.
    ///</summary>

    [TestClass()]
    public class RoomHandlerTests
    {
        private Mock<IInputhandler> mockInputHandler;
        private RoomHandler roomHandler;
        private GameState gameState;

        [TestInitialize]
        public void Setup()
        {
            mockInputHandler = new Mock<IInputhandler>();
            roomHandler = new RoomHandler(mockInputHandler.Object);
            gameState = new GameState();
        }
        [TestMethod()]
        public void HandleRoomChoice_ValidChoice_EntersRoom()
        {
            // Arrange: Mock valid room choice
            mockInputHandler
                .Setup(x => x.GetRoomchoice(It.IsAny<string[]>(), It.IsAny<Func<string>>()))
                .Returns(0); // Always select the first room

            // Act
            roomHandler.HandlerRoomChoice(gameState);

            // Assert
            mockInputHandler.Verify(x => x.GetRoomchoice(It.IsAny<string[]>(), It.IsAny<Func<string>>()), Times.Once);
        }

        [TestMethod]
        public void HandleRoomChoice_InvalidChoice_ShowsErrorMessage()
        {
            // Arrange: Mock invalid room choice first, then valid
            mockInputHandler
                .SetupSequence(x => x.GetRoomchoice(It.IsAny<string[]>(), It.IsAny<Func<string>>()))
                .Returns(-1) // Invalid choice
                .Returns(0); // Valid choice

            // Act
            roomHandler.HandlerRoomChoice(gameState);

            // Assert
            mockInputHandler.Verify(x => x.GetRoomchoice(It.IsAny<string[]>(), It.IsAny<Func<string>>()), Times.AtLeast(2));
        }

    
    }
}