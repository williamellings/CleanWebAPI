using MediatR;

namespace CleanWebAPI.Application.Products.Commands;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    Guid CategoryId) : IRequest;