using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Components;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PlugboardTests
    {
        public PlugboardTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void SetWiring_ShouldAdd1Wiring()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();

            // Act
            plugboard.SetWiring('a', 'h');
            var wiring = plugboard.GetWiring();

            // Assert
            Assert.AreEqual(1, wiring.Count);
        }

        [TestMethod]
        public void SetWiring_ShouldAdd1Wiring_WhenDuplicateKey()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();

            // Act
            plugboard.SetWiring('a', 'h');
            plugboard.SetWiring('a', 'i');
            var wiring = plugboard.GetWiring();

            // Assert
            Assert.AreEqual(1, wiring.Count);
            Assert.AreEqual('i', wiring['a']);
        }

        [TestMethod]
        public void SetWiring_ShouldNotAddWiring_WhenAlready10()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();
            plugboard.SetWiring('a', 'm');
            plugboard.SetWiring('b', 'n');
            plugboard.SetWiring('c', 'o');
            plugboard.SetWiring('d', 'p');
            plugboard.SetWiring('e', 'q');
            plugboard.SetWiring('f', 'r');
            plugboard.SetWiring('g', 's');
            plugboard.SetWiring('h', 't');
            plugboard.SetWiring('i', 'u');
            plugboard.SetWiring('j', 'v');

            // Act Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>( () => plugboard.SetWiring('k', 'w'));
        }


        [TestMethod]
        public void RemoveWiring_ShouldThrow_IfSettingLessThan0()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();

            // Act Assert
            Assert.ThrowsException<ArgumentException>( () => plugboard.RemoveWiring('a'));
        }

        [TestMethod]
        public void RemoveWiring_ShouldRemoveWiring()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();
            plugboard.SetWiring('b', 'x');

            // Act
            int initNumberOfPairs = plugboard.NumberPairs;
            plugboard.RemoveWiring('b');

            // Act Assert
            Assert.IsTrue(1 == initNumberOfPairs);
            Assert.IsTrue(0 == plugboard.NumberPairs);
        }

        [TestMethod]
        public void RemoveWiring_ShouldThrow_IfKeyDoesntExist()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();
            plugboard.SetWiring('b', 'x');

            // Act Assert
            Assert.ThrowsException<ArgumentException>( () => plugboard.RemoveWiring('c'));

            // Assert 
            Assert.IsTrue(1 == plugboard.NumberPairs);
        }




        [TestMethod]
        public void ConvertLetter_ShouldConvertLetter_WhenKeyExists()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();
            plugboard.SetWiring('a', 'k');

            // Assert
            Assert.AreEqual('k', plugboard.ConvertLetter('a'));
        }

        [TestMethod]
        public void ConvertLetter_ShouldReturnLetter_WhenKeyDoesntExists()
        {
            // Arrange
            Plugboard plugboard = new Plugboard();
            plugboard.SetWiring('a', 'k');

            // Assert
            Assert.AreEqual('f', plugboard.ConvertLetter('f'));
        }


    }
}
