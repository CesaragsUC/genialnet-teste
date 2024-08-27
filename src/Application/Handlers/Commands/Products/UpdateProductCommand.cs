using Application.DTOs.Product;
using Application.DTOs.Supplier;
using Application.Extensions;
using Application.Handlers.Validators;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Products;



public record UpdateProductCommand : IRequest<Result<ProductDto>>
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public UpdateProductCommand(ProductDto product)
    {
        Id = product.Id;
        Name = product.Name;
        Brand = product.Brand;
        Description = product.Description;

    }
}


public class UpdateProductCommandHandler(IProductRespository repository,
    ISupplierRespository respository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateProductCommand, Result<ProductDto>>
{

    public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var vaidator = new UpdateProductCommandValidator();
        var result = vaidator.Validate(request);

        if (!result.IsValid)
            return await Result<ProductDto>.FailureAsync(default, result.Errors.Select(x => x.ErrorMessage).ToList());

        var suplier = await respository.Get(request.SupplierId);

        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Brand = request.Brand,
            Description = request.Description,
        };

        await unitOfWork.Repository<Product>().UpdateAsync(product);

        if (!await unitOfWork.Save(cancellationToken))
            return await Result<ProductDto>.FailureDbAsync(new ProductDto(), "Houve uma falha interna no servidor");

        return await Result<ProductDto>.SuccessAsync(product.ToDto());
    }
}