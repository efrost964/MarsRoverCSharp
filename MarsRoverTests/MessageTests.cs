using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands;
        Message message;
        [TestInitialize]
        public void CreateEnvironment()
        {
            commands = new Command[] { new Command("foo", 0), new Command("bar", 20) };
            message = new Message("name", commands);
        }

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {

            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message name required.", ex.Message);
            }

        }
        [TestMethod]
        public void ConstructorSetsName()
        {
            Assert.AreEqual("name", message.Name);
        }
        [TestMethod]
        public void ConstructorSetsCommandFeild()
        {
            Assert.AreEqual<string>("foo", message.Commands[0].CommandType);
        }

    }
}
