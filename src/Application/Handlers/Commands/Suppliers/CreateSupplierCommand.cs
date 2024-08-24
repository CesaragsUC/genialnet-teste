using Application.DTOs.Adress;
using Application.DTOs.Supplier;
using Application.Extensions;
using Application.Handlers.Validators;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Suppliers;

public class CreateSupplierCommand : IRequest<Result<SupplierDto>>
{
    public string? Name { get; set; }

    public string? CNPJ { get; set; }

    public string? Phone { get; set; }

    public AddressDto Address { get; set; }

    public CreateSupplierCommand(SupplierDto dto )
    {
        Name = dto.Name;
        CNPJ = dto.CNPJ;
        Phone = dto.Phone;
        Address = dto.Address;

    }
}

public class CreateSupplierCommandHandler : 
    IRequestHandler<CreateSupplierCommand, Result<SupplierDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRespository _respository;

    public CreateSupplierCommandHandler(IUnitOfWork unitOfWork,
        ISupplierRespository respository)
    {
        _unitOfWork = unitOfWork;
        _respository = respository;
    }

    public async Task<Result<SupplierDto>> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
    {
        var vaidator = new CreateSupplierCommandValidator();
        var result = vaidator.Validate(command);

        if (!result.IsValid)
            return await Result<SupplierDto>.FailureAsync(default, result.Errors.Select(x => x.ErrorMessage).ToList());

        if(await CheckExistentSupplier(command.CNPJ))
            return await Result<SupplierDto>.FailureAsync(new SupplierDto(), "Fornecedor já cadastrado");

        await _unitOfWork.Repository<Domain.Entities.Supplier>().AddAsync(await BuildSupplier(command));

        if (!await _unitOfWork.Save(cancellationToken))
            return await Result<SupplierDto>.FailureDbAsync(new SupplierDto(), "Houve uma falha interna no servidor");

        return await Result<SupplierDto>.SuccessAsync(BuildSupplier(command).Result.ToDto());
    }


    private async Task<bool> CheckExistentSupplier(string cnpj)
    {
        var result = await _respository.GetAll();
        return result.Any(x => x.CNPJ == cnpj);
    }

    private async Task<Domain.Entities.Supplier> BuildSupplier(CreateSupplierCommand command)
    {
        var supplier = new Domain.Entities.Supplier
        {
            Name = command.Name,
            CNPJ = command.CNPJ,
            Phone = command.Phone
        };

        var address = new Address
        {
            Street = command.Address?.Street,
            Number = command.Address?.Number,
            Complement = command.Address?.Complement,
            PostalCode = command.Address?.PostalCode,
            Neighborhood = command.Address?.Neighborhood,
            City = command.Address?.City,
            State = command.Address?.State
        };

        supplier.Address = address;

        return supplier;
    }
}