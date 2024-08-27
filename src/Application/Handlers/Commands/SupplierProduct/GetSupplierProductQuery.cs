using Application.DTOs.ProductSupplier;
using Application.Extensions;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Products;


public record GetSupplierProductQuery : IRequest<Result<SupplierProductDto>>
{
    public Guid Id { get; set; }
    public GetSupplierProductQuery(Guid id)
    {
        Id = id;
    }
}

public class GetSupplierProductQueryHandler(ISupplierProductRespository respository) :
    IRequestHandler<GetSupplierProductQuery, Result<SupplierProductDto>>
{

    public async Task<Result<SupplierProductDto>> Handle(GetSupplierProductQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await respository.Get(request.Id);

        if (entity == null) {
            return await Result<SupplierProductDto>.FailureAsync("Dados não encontrado!");
        }

        return await Result<SupplierProductDto>.SuccessAsync(entity.ToDto());
    }
}
