using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTest
{
    [TestClass]
    public class TodoItemTest
    {
        private readonly TodoItem _validTodo = new TodoItem("Nova tarefa", DateTime.Now, "mariliamendonca");

        [TestMethod]
        public void Dado_um_novo_Todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}