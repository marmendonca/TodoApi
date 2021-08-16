using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handler;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTest
{
    [TestClass]
    public class UpdateTodoHandlerTest
    {
        private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand(Guid.NewGuid(), "", "");

        private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand(Guid.NewGuid(), "Tarefa titulada", "mariliamendonca");

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        private GenericCommandResult _result = new GenericCommandResult();

        public UpdateTodoHandlerTest()
        {
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
