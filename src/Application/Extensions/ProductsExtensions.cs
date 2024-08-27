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
            Brand = product.Brand,
        };
    }
}
