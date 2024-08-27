using Application.DTOs.Supplier;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Product;

public class ProductDto
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Brand { get; set; }

    [Required]
    public string? Description { get; set; }

}
