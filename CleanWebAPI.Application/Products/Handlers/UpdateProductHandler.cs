using CleanWebAPI.Application.Products.Commands;
using CleanWebAPI.Domain.Interfaces;
using MediatR;

namespace CleanWebAPI.Application.Products.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product != null)
        {
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;

            _repository.Update(product);
            await _repository.SaveChangesAsync();
        }
    }
}