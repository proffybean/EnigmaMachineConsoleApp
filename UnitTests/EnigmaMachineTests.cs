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
            
        }

        [TestInitialize]
        public void TestInitialize()
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
        public void EnimagmaMachine_ShouldDecodeWord_AfterEncoding()
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

        [TestMethod]
        public void EnimagmaMachine_ShouldDecodeWordWithSpaces_AfterEncoding()
        {
            // Arrange
            string initialMessage = "hello there";

            // Act
            string encodedMessage = enigmaMachine.Encode(initialMessage);
            enigmaMachine.SetRotorDials('a', 'a', 'z');
            string decodedMessage = enigmaMachine.Encode(encodedMessage);

            // Assert
            Assert.AreEqual(initialMessage.Replace(" ", ""), decodedMessage);
        }

        [TestMethod]
        public void EnimagmaMachine_ShouldDecodeWordWithCapitals_AfterEncoding()
        {
            // Arrange
            string initialMessage = "HelloThere";

            // Act
            string encodedMessage = enigmaMachine.Encode(initialMessage);
            enigmaMachine.SetRotorDials('a', 'a', 'z');
            string decodedMessage = enigmaMachine.Encode(encodedMessage);

            // Assert
            Assert.AreEqual(initialMessage.ToLower(), decodedMessage);
        }

        [TestMethod]
        public void EnigmaMachine_2ndRotorShouldTick_WhenFirstRotorPassTickPoint()
        {
            // Arrange
            string initialMessage = "epiphany";
            enigmaMachine.SetRotorDials('a', 'a', 't');

            // Act
            string encodedMessage = enigmaMachine.Encode(initialMessage);
            enigmaMachine.SetRotorDials('a', 'a', 't');
            string decodedMessage = enigmaMachine.Encode(encodedMessage);

            // Assert 
            Assert.AreEqual("bxheqcme", encodedMessage);
            Assert.AreEqual(initialMessage, decodedMessage);
        }

        [TestMethod]
        public void EnigmaMachine_2ndAnd3rdRotorShouldTick_WhenFirstRotorPassesTickPoint()
        {
            // Arrange
            string initialMessage = "nemesis";
            enigmaMachine.SetRotorDials('a', 'e', 't');

            // Act
            string encodedMessage = enigmaMachine.Encode(initialMessage);
            enigmaMachine.SetRotorDials('a', 'e', 't');
            string decodedMessage = enigmaMachine.Encode(encodedMessage);

            // Assert 
            Assert.AreEqual("zpeizdr", encodedMessage);
            Assert.AreEqual(initialMessage, decodedMessage);
        }

    }
}
