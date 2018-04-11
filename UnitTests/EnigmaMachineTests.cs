using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Components;
using static Components.Constants;

namespace UnitTests
{
    [TestClass]
    public class EnigmaMachineTests
    {

        public static EnigmaMachine enigmaMachine;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            enigmaMachine = new EnigmaMachine();
            enigmaMachine.SetPlugboardPair('h', 's');
            enigmaMachine.SetPlugboardPair('a', 'e');
            enigmaMachine.SetPlugboardPair('d', 'j');
            enigmaMachine.SetPlugboardPair('p', 'q');
            enigmaMachine.SetPlugboardPair('g', 'm');
            enigmaMachine.SetRotorDials('a', 'a', 'z');
        }

        [TestMethod]
        public void EnimagmaMachine_ShouldEncodeWord_When()
        {
            // Arrange

            // Act
            string encodedMessage = enigmaMachine.Encode("hello");

            // Assert
            Assert.AreEqual("lbabg", encodedMessage);
        }

        [TestMethod]
        public void EnimagmaMachine_ShouldDecodeWord_WhenEncoded()
        {
            // Arrange
            string initialMessage = "hello";

            // Act
            string encodedMessage = enigmaMachine.Encode(initialMessage);
            enigmaMachine.SetRotorDials('a', 'a', 'z');
            string decodedMessage = enigmaMachine.Encode(encodedMessage);

            // Assert
            Assert.AreEqual(initialMessage, decodedMessage);
        }

    }
}
