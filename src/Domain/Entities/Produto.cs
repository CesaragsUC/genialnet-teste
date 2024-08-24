using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;
public class Product : BaseEntity
{
    public Guid SupplierId { get; set; }
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public string? Description { get; set; }

    public decimal? Price { get; set; }

    /* EF Relations */
    public Supplier Supplier { get; set; }
}
