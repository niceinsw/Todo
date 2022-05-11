using Microsoft.AspNetCore.Mvc;
using Todo.Api.Requests;

namespace Todo.Api.Controllers;

[Route("todo")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] bool includecompleted = false) =>
        Ok(await _mediator.Send(new ListTodoItemsRequest(includecompleted)));

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateTodoItemRequest request) =>
        Ok(await _mediator.Send(request));
        
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateTodoItemRequest request)
    {
        var result = await _mediator.Send(request);

        return result == null ? NotFound() : Ok(result);
    }
}