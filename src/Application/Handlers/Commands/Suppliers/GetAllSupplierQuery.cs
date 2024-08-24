using Application.DTOs.Supplier;
using Application.Extensions;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Suppliers;

public record GetAllSupplierQuery : IRequest<Result<IEnumerable<SupplierDto>>>;

public class GetAllSupplierQueryHandler : 
    IRequestHandler<GetAllSupplierQuery, Result<IEnumerable<SupplierDto>>>
{

    private readonly ISupplierRespository _respository;
    public GetAllSupplierQueryHandler(IUnitOfWork unitOfWork,
        ISupplierRespository respository)
    {
        _respository = respository;
    }

    public async Task<Result<IEnumerable<SupplierDto>>> Handle(GetAllSupplierQuery request,
        CancellationToken cancellationToken)
    {
        var supliers = await _respository.GetAll();

        return await Result<IEnumerable<SupplierDto>>.SuccessAsync(supliers.Select(x=> x.ToDto()).ToList());
    }
}
