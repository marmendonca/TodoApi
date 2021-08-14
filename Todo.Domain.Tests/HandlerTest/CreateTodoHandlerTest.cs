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

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        private GenericCommandResult _result = new GenericCommandResult();

        public CreateTodoHandlerTest()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Given_An_Invalid_Command()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Given_An_Valid_Command()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}

