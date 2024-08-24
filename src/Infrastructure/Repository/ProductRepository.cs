using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductRepository : IProductRespository
{
    private readonly GenialnetDbContext _context;

    public ProductRepository(GenialnetDbContext context)
    {
        _context = context;
    }


    public async Task Add(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> Get(Guid id)
    {

        return await _context.Products
                          .Include(p => p.Supplier)
                          .SingleOrDefaultAsync(p => p.Id == id);

    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products
            .Include(p => p.Supplier)
            .AsNoTracking().ToListAsync();
    }

    public async Task Remove(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}