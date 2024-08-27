using Domain.Common;

namespace Domain.Entities;

public class Supplier : BaseEntity
{
    public string? Name { get; set; }
    public string? CNPJ { get; set; }
    public string? Phone { get; set; }

    public Address Address { get; set; }

    public ICollection<SupplierProduct> SupplierProducts { get; set; }
}
