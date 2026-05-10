using CleanWebAPI.Application.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanWebAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        
        var productId = await _mediator.Send(command);

        // Returns HTTP 201 Created
        return CreatedAtAction(nameof(CreateProduct), new { id = productId }, productId);


    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent(); // Returnerar 204 No Content vid lyckad borttagning
    }
}
