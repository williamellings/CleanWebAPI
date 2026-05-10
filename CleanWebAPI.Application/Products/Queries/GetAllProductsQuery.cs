using CleanWebAPI.Application.DTOs;
using MediatR;

namespace CleanWebAPI.Application.Products.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;