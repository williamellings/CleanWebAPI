using CleanWebAPI.Application.Products.Commands;
using CleanWebAPI.Domain.Entities;
using CleanWebAPI.Domain.Interfaces;
using MediatR;

namespace CleanWebAPI.Application.Products.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        return product.Id;
    }
}