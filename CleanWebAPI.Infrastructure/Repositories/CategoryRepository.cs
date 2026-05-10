using CleanWebAPI.Domain.Entities;
using CleanWebAPI.Domain.Interfaces;

namespace CleanWebAPI.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category) => await _context.Categories.AddAsync(category);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}