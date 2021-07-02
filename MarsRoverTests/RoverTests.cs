using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        Rover test_rover;
        [TestInitialize]
        public void CreateRover()
        {
            test_rover = new Rover(5000);
        }
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Assert.AreEqual("NORMAL", test_rover.Mode);
        }

    }
}
