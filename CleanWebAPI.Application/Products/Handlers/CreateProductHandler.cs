using AutoMapper;
using CleanWebAPI.Application.DTOs;
using CleanWebAPI.Application.Products.Queries;
using CleanWebAPI.Domain.Interfaces;
using MediatR;

namespace CleanWebAPI.Application.Products.Handlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        
        var products = await _productRepository.GetAllAsync();

        
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

        return productDtos;
    }
}