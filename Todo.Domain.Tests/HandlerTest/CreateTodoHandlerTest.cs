using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handler;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTest
{
    [TestClass]
    public class CreateTodoHandlerTest
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");

        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Tarefa titulada", DateTime.Now, "mariliamendonca");

        [TestMethod]
        public void Given_An_Invalid_Command()
        {
            _invalidCommand.Validate();
            var handler = new TodoHandler(new FakeTodoRepository());
            handler.Handle(_invalidCommand);
            Assert.AreEqual(_invalidCommand.Invalid, true);
        }

        [TestMethod]
        public void Given_An_Valid_Command()
        {
            _validCommand.Validate();
            var handler = new TodoHandler(new FakeTodoRepository());
            handler.Handle(_validCommand);
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}

