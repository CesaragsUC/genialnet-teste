using Domain.Common;

namespace Domain.Entities;

public class SupplierProduct 
{
    public Guid ProductId { get; set; }

    public Guid SupplierId { get; set; }

    public decimal Price { get; set; }

    public Product Product { get; set; }
    public Supplier Supplier { get; set; }

}
