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
    public class GameDisplayTests
    {
        [TestMethod()]
        public void ShowMessage_DisplaysMessageWithDefaultColor()
        {
            // Arrange: Set up the environment for the test
            // Redirect the console output to a StringWriter to capture printed output
            var mockConsoleOutput = new StringWriter();
            Console.SetOut(mockConsoleOutput);
            var display = new GameDisplay(); // Create an instance of the class to test

            // Act: Execute the method to test
            display.ShowMessage("Test Message");

            // Assert: Verify that the output matches expectations
            var output = mockConsoleOutput.ToString(); // Capture the output from the console
            StringAssert.Contains(output, "Test Message"); // Check if the message was displayed correctly
        }

        [TestMethod()]
        public void ShowProgress_DisplaysPlayerProgress()
        {
            // Arrange: Set up test dependencies
            // Redirect the console output to a StringWriter to capture printed output
            var mockConsoleOutput = new StringWriter();
            Console.SetOut(mockConsoleOutput);
            var display = new GameDisplay(); // Create an instance of the class to test

            // Act: Call the method to test
            display.ShowProgress("Player1", 2, 5, 3);

            // Assert: Verify the output is correct
            var output = mockConsoleOutput.ToString(); // Capture the output from the console
            StringAssert.Contains(output, "Player1"); // Check if Player1 is displayed
            StringAssert.Contains(output, "Magic Balls Found: 2/5"); // Check the magic ball progress
            StringAssert.Contains(output, "Lives Remaining: 3"); // Check the number of lives remaining
        }

        
    }
}