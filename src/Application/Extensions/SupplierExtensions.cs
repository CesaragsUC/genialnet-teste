using Application.DTOs.Adress;
using Application.DTOs.Supplier;
using Domain.Entities;

namespace Application.Extensions;

public static class SupplierExtensions
{
    public static SupplierDto ToDto(this Domain.Entities.Supplier supplier)
    {
        return new SupplierDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            CNPJ = supplier.CNPJ,
            Phone = supplier.Phone,
            Address = supplier.Address.ToDto(),
           // Products = supplier.Products.Select(p => p.ToDto())
        };
    }

    public static AddressDto ToDto(this Address address)
    {
        if(address == null) return new AddressDto();

        return new AddressDto
        {
            Id = address.Id,
            Street = address.Street,
            Number = address.Number,
            Complement = address.Complement,
            PostalCode = address.PostalCode,
            Neighborhood = address.Neighborhood,
            City = address.City,
            State = address.State
        };

    }


}
