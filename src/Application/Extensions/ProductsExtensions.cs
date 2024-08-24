using Application.DTOs.Product;

namespace Application.Extensions;

public static class ProductsExtensions
{
    public static ProductDto ToDto(this Domain.Entities.Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Brand = product.Brand,
            SupplierId = product.SupplierId,
            Supplier = new DTOs.Supplier.SupplierDto
            {
                Id = product.Supplier.Id,
                Name = product.Supplier.Name,
                CNPJ = product.Supplier.CNPJ,
                Phone = product.Supplier.Phone,
            }
        };
    }
}
