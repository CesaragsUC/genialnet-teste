using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class SupplierProductRepository : ISupplierProductRespository
{
    private readonly GenialnetDbContext _context;

    public SupplierProductRepository(GenialnetDbContext context)
    {
        _context = context;
    }


    public async Task Add(SupplierProduct entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<SupplierProduct> Get(Guid supplierId)
    {

        return await _context.SupplierProducts
                     .Include(sp => sp.Supplier)
                     .Include(sp => sp.Product)
                     .FirstOrDefaultAsync(sp => sp.SupplierId == supplierId);


    }

    public async Task<IEnumerable<SupplierProduct>> GetAll()
    {
        return await _context.SupplierProducts.Include(sp => sp.Supplier)
                     .Include(sp => sp.Product).ToListAsync();
    }

    public async Task Remove(SupplierProduct entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(SupplierProduct entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}