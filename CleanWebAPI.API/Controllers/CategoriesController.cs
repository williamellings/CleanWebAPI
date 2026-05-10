using CleanWebAPI.Application.Categories.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanWebAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriesController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}