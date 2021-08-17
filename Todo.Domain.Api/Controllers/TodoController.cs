using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handler;
using Todo.Domain.Infra.Contexts;

namespace Todo.Domain.Api.Controllers
{
    [Route("v1/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "mariliamendonca";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
