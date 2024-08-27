using Application.DTOs.Product;
using Application.DTOs.Supplier;

namespace Application.DTOs.ProductSupplier;

public record SupplierProductDto
{
    public Guid ProductId { get; set; }

    public Guid SupplierId { get; set; }

    public string SupplierName { get; set; }

    public string ProductName { get; set; }

    public decimal? Price { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }
    public IEnumerable<SupplierDto> Suppliers { get; set; }
}