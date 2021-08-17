using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handler;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [Route("v1/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
        {
            return repository.GetAll("mariliamendonca");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repository)
        {
            return repository.GetAllDone("mariliamendonca");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices]ITodoRepository repository)
        {
            return repository.GetAllUndone("mariliamendonca");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("mariliamendonca", DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetInactiveForToday([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("mariliamendonca", DateTime.Now.Date, false);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("mariliamendonca", DateTime.Now.AddDays(1), false);
        }

        [Route("undone/tomorow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("mariliamendonca", DateTime.Now.AddDays(1), true);
        }

        [Route("{id:int}")]
        [HttpGet]
        public TodoItem GetById(Guid id, [FromServices]ITodoRepository repository)
        {
            return repository.GetById(id, "mariliamendonca");
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "mariliamendonca";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody]UpdateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "mariliamendonca";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult MarkAsDone([FromBody]MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "mariliamendonca";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone([FromBody]MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "mariliamendonca";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
