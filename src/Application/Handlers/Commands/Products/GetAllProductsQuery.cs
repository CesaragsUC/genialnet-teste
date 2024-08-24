using Application.DTOs.Product;
using Application.Extensions;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Products;

public record GetAllProductsQuery : IRequest<Result<IEnumerable<ProductDto>>>;

public class GetAllProductsQueryHandler (IProductRespository respository) :
    IRequestHandler<GetAllProductsQuery, Result<IEnumerable<ProductDto>>>
{
    public async Task<Result<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await respository.GetAll();

        return await Result<IEnumerable<ProductDto>>.SuccessAsync(products.Select(x => x.ToDto()).ToList());
    }
}
