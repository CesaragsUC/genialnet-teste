using Application.DTOs.ProductSupplier;
using Application.Extensions;
using Application.Handlers.Validators;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Products;

public record CreateSupplierProductCommand : IRequest<Result<SupplierProductDto>>
{
    public Guid SupplierId { get; set; }
    public Guid ProductId { get; set; }

    public decimal? Price { get; set; }


    public CreateSupplierProductCommand(SupplierProductDto entity)
    {
        SupplierId = entity.SupplierId;
        ProductId = entity.ProductId;
        Price = entity.Price;

    }
}


public class CreateSupplierProductCommandHandler (ISupplierProductRespository respository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSupplierProductCommand, Result<SupplierProductDto>>
{

    public async Task<Result<SupplierProductDto>> Handle(CreateSupplierProductCommand request, CancellationToken cancellationToken)
    {
        var vaidator = new CreateSupplierProductCommandValidator();
        var result = vaidator.Validate(request);

        if (!result.IsValid)
            return await Result<SupplierProductDto>.FailureAsync(default, result.Errors.Select(x => x.ErrorMessage).ToList());

        if(await CheckExistentProduct(request.ProductId,request.SupplierId))
            return await Result<SupplierProductDto>.FailureAsync("Produto já cadastrado para esse fornecedor!");

        var entity = new Domain.Entities.SupplierProduct
        {
            SupplierId = request.SupplierId,
            ProductId = request.ProductId,
            Price = request.Price ?? 0

        };

        await respository.Add(entity);

        return await Result<SupplierProductDto>.SuccessAsync(entity.ToDto());
    }

    private async Task<bool> CheckExistentProduct(Guid productId,Guid supplierId)
    {
        var result = await respository.GetAll();
        return result.Any(x => x.SupplierId == supplierId && x.ProductId == productId);
    }
}