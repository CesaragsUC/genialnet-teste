using Application.DTOs.Adress;
using Application.DTOs.Supplier;
using Application.Extensions;
using Application.Handlers.Commands.Suppliers;
using Application.Handlers.Validators;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Supplier;

public class UpdateSupplierCommand : IRequest<Result<SupplierDto>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string? CNPJ { get; set; }

    public string? Phone { get; set; }

    public AddressDto Address { get; set; }

    public UpdateSupplierCommand(SupplierDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        CNPJ = dto.CNPJ;
        Phone = dto.Phone;
        Address = dto.Address;

    }
}

public class UpdateSupplierCommandCommandHandler : IRequestHandler<UpdateSupplierCommand, Result<SupplierDto>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRespository _respository;

    public UpdateSupplierCommandCommandHandler(IUnitOfWork unitOfWork,
        ISupplierRespository respository)
    {
        _unitOfWork = unitOfWork;
        _respository = respository;
    }

    public async Task<Result<SupplierDto>> Handle(UpdateSupplierCommand command, CancellationToken cancellationToken)
    {
        var vaidator = new UpdateSupplierCommandValidator();
        var result = vaidator.Validate(command);

        if (!result.IsValid)
            return await Result<SupplierDto>.FailureAsync(default, result.Errors.Select(x => x.ErrorMessage).ToList());


        await _unitOfWork.Repository<Domain.Entities.Supplier>().UpdateAsync(await BuildSupplier(command));

        await _unitOfWork.Repository<Address>().UpdateAsync(await BuildAdress(command));

        if (!await _unitOfWork.Save(cancellationToken))
            return await Result<SupplierDto>.FailureDbAsync(new SupplierDto(), "Houve uma falha interna no servidor");

        return await Result<SupplierDto>.SuccessAsync(BuildSupplier(command).Result.ToDto());
    }

    private async Task<bool> CheckExistentSupplier(string cnpj)
    {
        var result = await _respository.GetAll();
        return result.Any(x => x.CNPJ == cnpj);
    }

    private async Task<Domain.Entities.Supplier> BuildSupplier(UpdateSupplierCommand command)
    {
        var supplier = new Domain.Entities.Supplier
        {
            Id = command.Id,
            Name = command.Name,
            CNPJ = command.CNPJ,
            Phone = command.Phone
        };

        var address = new Address
        {
            Id = command.Address.Id,
            Street = command.Address?.Street,
            Number = command.Address?.Number,
            Complement = command.Address?.Complement,
            PostalCode = command.Address?.PostalCode,
            Neighborhood = command.Address?.Neighborhood,
            City = command.Address?.City,
            State = command.Address?.State,
            SupplierId = supplier.Id
        };

        supplier.Address = address;

        return supplier;
    }

    private async Task<Address> BuildAdress(UpdateSupplierCommand command)
    {

        var address = new Address
        {
            Id = command.Address.Id,
            Street = command.Address?.Street,
            Number = command.Address?.Number,
            Complement = command.Address?.Complement,
            PostalCode = command.Address?.PostalCode,
            Neighborhood = command.Address?.Neighborhood,
            City = command.Address?.City,
            State = command.Address?.State,
            SupplierId = command.Id
        };

        return address;
    }
}