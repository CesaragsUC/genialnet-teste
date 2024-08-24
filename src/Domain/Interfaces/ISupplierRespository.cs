using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ISupplierRespository
{
    Task Add(Supplier supplier);
    Task Update(Supplier supplier);
    Task Remove(Supplier supplier);
    Task<Supplier> Get(Guid id);
    Task<IEnumerable<Supplier>> GetAll();
}
