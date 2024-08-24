using Application.DTOs.Adress;
using Application.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Supplier;

public record SupplierDto
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? CNPJ { get; set; }

    [Required]
    public string? Phone { get; set; }

    public AddressDto Address { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }
}