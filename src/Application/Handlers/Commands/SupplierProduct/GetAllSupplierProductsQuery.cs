using Application.DTOs.ProductSupplier;
using Application.Extensions;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.SupplierProduct;

public record GetAllSupplierProductsQuery : IRequest<Result<IEnumerable<SupplierProductDto>>>;

public class GetAllProductsQueryHandler(ISupplierProductRespository respository) :
    IRequestHandler<GetAllSupplierProductsQuery, Result<IEnumerable<SupplierProductDto>>>
{
    public async Task<Result<IEnumerable<SupplierProductDto>>> Handle(GetAllSupplierProductsQuery request,
        CancellationToken cancellationToken)
    {
        var entities = await respository.GetAll();

        return await Result<IEnumerable<SupplierProductDto>>.SuccessAsync(entities.Select(x => x.ToDto()).ToList());
    }
}