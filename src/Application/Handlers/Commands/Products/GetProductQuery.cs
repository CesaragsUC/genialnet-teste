using Application.DTOs.Product;
using Application.Extensions;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Products;


public record GetProductQuery : IRequest<Result<ProductDto>>
{
    public Guid Id { get; set; }
    public GetProductQuery(Guid id)
    {
        Id = id;
    }
}

public class GetProductQueryHandler(IProductRespository respository) :
    IRequestHandler<GetProductQuery, Result<ProductDto>>
{

    public async Task<Result<ProductDto>> Handle(GetProductQuery request,
        CancellationToken cancellationToken)
    {
        var product = await respository.Get(request.Id);

        if (product == null) {
            return await Result<ProductDto>.FailureAsync("Produto não encontrado!");
        }

        return await Result<ProductDto>.SuccessAsync(product.ToDto());
    }
}
