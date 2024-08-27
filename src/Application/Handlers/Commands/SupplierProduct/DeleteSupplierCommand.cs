using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Supplier;

public record DeleteSupplierProdutoCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public DeleteSupplierProdutoCommand(Guid supplierId)
    {
        Id = supplierId;
    }
}

public class DeleteSupplierProdutoCommandQueryHandler :
    IRequestHandler<DeleteSupplierProdutoCommand, Result<bool>>
{

    private readonly ISupplierProductRespository _respository;
    public DeleteSupplierProdutoCommandQueryHandler(IUnitOfWork unitOfWork,
        ISupplierProductRespository respository)
    {
        _respository = respository;
    }

    public async Task<Result<bool>> Handle(DeleteSupplierProdutoCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _respository.Get(request.Id);

        await _respository.Remove(entity);

        return await Result<bool>.SuccessAsync("removido!");
    }
}