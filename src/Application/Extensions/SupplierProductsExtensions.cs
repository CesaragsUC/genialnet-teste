using Application.DTOs.ProductSupplier;
using Domain.Entities;

namespace Application.Extensions;

public static class SupplierProductsExtensions
{
    public static SupplierProductDto ToDto(this SupplierProduct entity)
    {
        return new SupplierProductDto
        {
            SupplierId = entity.SupplierId,
            ProductId = entity.ProductId,
            ProductName = entity?.Product?.Name,
            SupplierName = entity?.Supplier?.Name,
            Price = entity.Price,

        };
    }

}
