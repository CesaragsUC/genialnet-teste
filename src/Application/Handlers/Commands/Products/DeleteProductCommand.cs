using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.Products;


public record DeleteProductCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }
}

public class DeleteProductCommandQueryHandler(IProductRespository respository) :
    IRequestHandler<DeleteProductCommand, Result<bool>>
{

    public async Task<Result<bool>> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await respository.Get(request.Id);

        if (product == null)
            return await Result<bool>.FailureAsync("Produto não encontrado!");

        await respository.Remove(product);

        return await Result<bool>.SuccessAsync("Produto removido!");
    }
}