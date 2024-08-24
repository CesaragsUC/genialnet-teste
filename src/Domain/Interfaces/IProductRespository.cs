using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRespository
{
    Task Add(Product product);
    Task Update(Product product);
    Task Remove(Product product);
    Task<Product> Get(Guid id);
    Task<IEnumerable<Product>> GetAll();
}