using MediatR;


namespace CleanWebAPI.Application.Products.Commands;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    Guid CategoryId) : IRequest<Guid>;