using CleanWebAPI.Application.Products.Commands;
using CleanWebAPI.Domain.Interfaces;
using MediatR;

namespace CleanWebAPI.Application.Products.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product != null)
        {
            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }

    }
}