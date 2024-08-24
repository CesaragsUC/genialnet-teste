using Application.DTOs.Supplier;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Adress;

public class AddressDto
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid SupplierId { get; set; }

    [Required]
    public string? Street { get; set; }

    [Required]
    public int? Number { get; set; }

    public string? Complement { get; set; }

    [Required]
    public string? PostalCode { get; set; }

    [Required]
    public string? Neighborhood { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? State { get; set; }

    public SupplierDto Supplier { get; set; }
}
