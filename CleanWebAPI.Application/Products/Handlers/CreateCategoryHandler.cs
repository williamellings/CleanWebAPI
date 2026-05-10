using CleanWebAPI.Application.Categories.Commands;
using CleanWebAPI.Domain.Entities;
using CleanWebAPI.Domain.Interfaces; 
using MediatR;

namespace CleanWebAPI.Application.Categories.Handlers;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _repository; 

    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();

        return category.Id;
    }
}