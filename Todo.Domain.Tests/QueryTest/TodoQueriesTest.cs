using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Queries;

namespace Todo.Domain.Tests.QueryTest
{
    [TestClass]
    public class TodoQueriesTest
    {
        private List<TodoItem> _items;

        public TodoQueriesTest()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "andrebaltieri", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "andrebaltieri", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_mariliamendonca()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("mariliamendonca"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
