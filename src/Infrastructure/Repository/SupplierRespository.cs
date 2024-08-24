using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;


public class SupplierRespository : ISupplierRespository
{
    private readonly GenialnetDbContext _context;

    public SupplierRespository(GenialnetDbContext context)
    {
        _context = context;
    }

    public async Task Add(Supplier supplier)
    {
        _context.Add(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task<Supplier> Get(Guid id)
    {
        return await _context.Suppliers
            .Include(a => a.Address)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Supplier>> GetAll()
    {
        return await _context.Suppliers.Include(a => a.Address).
            AsNoTracking().ToListAsync();
    }

    public async Task Remove(Supplier supplier)
    {
        _context.Remove(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Supplier supplier)
    {
        _context.Entry(supplier).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
