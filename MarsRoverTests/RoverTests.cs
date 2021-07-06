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
        Command moveCommand;
        Command modeCommand;
        Command[] commands;
        Message message;
        [TestInitialize]
        public void CreateRover()
        {
            test_rover = new Rover(5000);
            moveCommand = new Command("MOVE", 4);
            modeCommand = new Command("MODE_CHANGE", "LOW_POWER");
        }
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Assert.AreEqual(5000, test_rover.Position);
        }
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Assert.AreEqual("NORMAL", test_rover.Mode);
        }
        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Assert.AreEqual(110, test_rover.GeneratorWatts);
        }
        [TestMethod]
        public void RespondsToModeChangeCommands()
        {
            commands = new Command[] { modeCommand };
            message = new Message("HOLY LUMP", commands);
            test_rover.RecieveMessage(message);
            Assert.AreEqual("LOW_POWER", test_rover.Mode);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DoesNotMoveInLOW_POWER()
        {
            commands = new Command[] { modeCommand, moveCommand };
            message = new Message("SHOOT", commands);
            test_rover.RecieveMessage(message);
            //Assert.AreEqual(5000, test_rover.Position);
            Assert.Fail("Rover cannot move in LOW_POWER mode.");
        }
        [TestMethod]
        public void RoverPositionChangesMoveCommand()
        {
            commands = new Command[] { moveCommand };
            message = new Message("dang", commands);
            test_rover.RecieveMessage(message);
            Assert.AreEqual(4, test_rover.Position);
        }

    }
}
