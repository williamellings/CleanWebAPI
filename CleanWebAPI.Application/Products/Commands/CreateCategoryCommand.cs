using MediatR;

namespace CleanWebAPI.Application.Categories.Commands;

public record CreateCategoryCommand(string Name) : IRequest<Guid>;