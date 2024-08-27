using Domain.Entities;

namespace Domain.Interfaces;

public interface ISupplierProductRespository
{
    Task Add(SupplierProduct entity);
    Task Update(SupplierProduct entity);
    Task Remove(SupplierProduct entity);
    Task<SupplierProduct> Get(Guid supplierId);
    Task<IEnumerable<SupplierProduct>> GetAll();
}