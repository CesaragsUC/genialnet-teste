using Application.DTOs.Supplier;
using Application.Extensions;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Suppliers;

public record GetSupplierQuery : IRequest<Result<SupplierDto>>
{
    public Guid Id { get; set; }
    public GetSupplierQuery(Guid id)
    {
        Id = id;
    }
}

public class GetSupplierQueryHandler : 
    IRequestHandler<GetSupplierQuery, Result<SupplierDto>>
{

    private readonly ISupplierRespository _respository;
    public GetSupplierQueryHandler(IUnitOfWork unitOfWork,
        ISupplierRespository respository)
    {
        _respository = respository;
    }

    public async Task<Result<SupplierDto>> Handle(GetSupplierQuery request,
        CancellationToken cancellationToken)
    {
        var suplier = await _respository.Get(request.Id);

        return await Result<SupplierDto>.SuccessAsync(suplier.ToDto());
    }
}
