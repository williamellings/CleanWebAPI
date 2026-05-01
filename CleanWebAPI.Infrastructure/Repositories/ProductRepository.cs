using CleanWebAPI.Domain.Entities;
using CleanWebAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanWebAPI.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id) => await _context.Products.FindAsync(id);

    public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

    public void Update(Product product) => _context.Products.Update(product);

    public void Delete(Product product) => _context.Products.Remove(product);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}