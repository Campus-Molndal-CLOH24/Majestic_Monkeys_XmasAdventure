using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xmasgame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmasgame.Interfaces;

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
            var inputHandler = new InputHandler();

            //act
            int result = inputHandler.GetRoomchoice(rooms, inputProvider);
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
            var inputHandler = new InputHandler();
            int inputIndex = 0; // Declare and initialize inputIndex
            //mock input provider
            Func<string> mockInputProvider = () =>
            {
                return mockInput[inputIndex++];
            };
            //act
            int result = inputHandler.GetRoomchoice(rooms, mockInputProvider);
            //assert
            Assert.AreEqual(1, result, $"Expected index 1 for 'Bedroom', but got {result}."); // Expecting index 1 for "Bedroom"
        }
        
        
        [TestMethod()]
        //scenario : Handles edge cases such as empty input or non-numeric input.  
        public void GetRoomchoice_InvalidInput_returnMinusOne()
        {
            //arrange  
            string[] rooms = { "Kitchen", "Bedroom", "Bathroom" };
            string[] mockInput = { "", "invalid", " " }; // simulate empty input, non-numeric input, and whitespace input.  
            int inputIndex = 0;
            var inputHandler = new InputHandler();

            // Mock input provider
            Func<string> mockInputProvider = () =>
            {
                if (inputIndex < mockInput.Length)
                {
                    return mockInput[inputIndex++];
                }
                return null; // Simulate no more input if the array is exhausted
            };
            //act and assert  
            foreach (var input in mockInput)
            {
                int result = inputHandler.GetRoomchoice(rooms, mockInputProvider);
                Assert.AreEqual(-1, result, $"Expected -1 for invalid input '{input}', but got {result}.");
                Console.WriteLine($"Tested input '{input}', received result: {result}");
            }
        }
    }
}