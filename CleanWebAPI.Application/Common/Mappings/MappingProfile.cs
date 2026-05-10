using AutoMapper;
using CleanWebAPI.Application.DTOs;
using CleanWebAPI.Domain.Entities;

namespace CleanWebAPI.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mappa från Product (Entity) till ProductDto
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}