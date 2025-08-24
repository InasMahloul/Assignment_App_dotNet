using Assignment_App.Application.Commands;
using Assignment_App.Application.Queries;
using Assignment_App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_App.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator) => _mediator = mediator;

      

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
        {
            try
            {
                var taskId = await _mediator.Send(command);
                return Ok(new { Id = taskId, Title = command.Title });
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
            }
        }

        [HttpGet]
        public async Task<List<TodoTask>> Get()
            => await _mediator.Send(new GetTasksQuery());
    }
}
