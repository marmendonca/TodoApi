using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTest
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");

        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Tarefa titulada", DateTime.Now, "mariliamendonca");

        [TestMethod]
        public void Given_An_Invalid_Command()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Given_An_Valid_Command()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
