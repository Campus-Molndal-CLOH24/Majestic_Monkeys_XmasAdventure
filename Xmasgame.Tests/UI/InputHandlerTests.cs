using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmasgame.UI.Tests
{
    [TestClass()]
    public class InputHandlerTests
    {
        [TestMethod()]
        //scenario : valid input macth with the index of the room and return correct index.
        public void GetRoomchoice_validInput_returnCorrectIndex()
        {
            //arrange
            string[] rooms = { "Kitchen", "Bedroom", "Bathroom" };
            Func<string> inputProvider = () => "2"; // Simulate user input "2"
            int Inputindex = 0; // index of the first room start at 0.
            
            //act
            int result = InputHandler.GetRoomchoice(rooms, inputProvider);
            //assert
            Assert.AreEqual(1, result);
        }
        [TestMethod()]
        //scenario : invalid input first, then valid input, should return correct index.
        public void GetRoomchoice_invalidThenValidInput_returnCorrectIndex()
        {
            //arrange
            string[] rooms = { "Kitchen", "Bedroom", "Bathroom" };
            string[] mockInput = { "invalid", "2" }; // simulate invalid input first, then valid input.
            int inputIndex = 0; // index of the first room start at 0.
            //mock input provider
            Func<string> mockInputProvider = () =>
            {
                return mockInput[inputIndex++];
            };
            //act
            int result = InputHandler.GetRoomchoice(rooms, mockInputProvider);
            //assert
            Assert.AreEqual(1, result, $"Expected index 1 for 'Bedroom', but got {result}."); // Expecting index 1 for "Bedroom"
        }
    }
}