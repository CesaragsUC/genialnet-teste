using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;
public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public string? Description { get; set; }

    public ICollection<SupplierProduct> SupplierProducts { get; set; }
}
