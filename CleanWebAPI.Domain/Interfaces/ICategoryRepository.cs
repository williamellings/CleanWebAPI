using CleanWebAPI.Domain.Entities;

namespace CleanWebAPI.Domain.Interfaces;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task SaveChangesAsync();
}