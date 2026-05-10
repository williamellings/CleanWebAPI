using CleanWebAPI.Application.Products.Commands;
using CleanWebAPI.Application.Products.Queries;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Skickar queryn genom MediatR
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID i URL:en matchar inte ID:t i bodyn.");

        await _mediator.Send(command);
        return NoContent(); // Returnerar 204 No Content vid lyckad uppdatering
    }
}
