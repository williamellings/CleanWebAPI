using MediatR;

namespace CleanWebAPI.Application.Products.Commands;

// Kommandot tar emot ID:t och returnerar ingenting (Unit/void)
public record DeleteProductCommand(Guid Id) : IRequest;