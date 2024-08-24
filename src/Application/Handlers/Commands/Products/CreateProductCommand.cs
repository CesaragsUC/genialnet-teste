﻿using Application.DTOs.Product;
using Application.Extensions;
using Application.Handlers.Validators;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Products;

public record CreateProductCommand : IRequest<Result<ProductDto>>
{
    public Guid SupplierId { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public CreateProductCommand(ProductDto product)
    {
        SupplierId = product.SupplierId;
        Name = product.Name;
        Brand = product.Brand;
        Description = product.Description;
        Price = product.Price;


    }
}


public class CreateProductCommandHandler (ISupplierRespository respository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, Result<ProductDto>>
{

    public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var vaidator = new CreateProductCommandValidator();
        var result = vaidator.Validate(request);

        if (!result.IsValid)
            return await Result<ProductDto>.FailureAsync(default, result.Errors.Select(x => x.ErrorMessage).ToList());

        var suplier = await respository.Get(request.SupplierId);

        var product = new Product
        {
            SupplierId = request.SupplierId,
            Name = request.Name,
            Brand = request.Brand,
            Description = request.Description,
            Price = request.Price,
            Supplier = suplier
        };

        await unitOfWork.Repository<Product>().AddAsync(product);

        if (!await unitOfWork.Save(cancellationToken))
            return await Result<ProductDto>.FailureDbAsync(new ProductDto(), "Houve uma falha interna no servidor");

        return await Result<ProductDto>.SuccessAsync(product.ToDto());
    }
}