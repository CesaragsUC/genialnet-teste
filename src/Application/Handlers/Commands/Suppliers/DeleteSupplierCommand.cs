using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Shared.Kernel;

namespace Application.Handlers.Commands.Supplier;

public record DeleteSupplierCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public DeleteSupplierCommand(Guid id)
    {
        Id = id;
    }
}

public class DeleteSupplierCommandQueryHandler :
    IRequestHandler<DeleteSupplierCommand, Result<bool>>
{

    private readonly ISupplierRespository _respository;
    public DeleteSupplierCommandQueryHandler(IUnitOfWork unitOfWork,
        ISupplierRespository respository)
    {
        _respository = respository;
    }

    public async Task<Result<bool>> Handle(DeleteSupplierCommand request,
        CancellationToken cancellationToken)
    {
        var suplier = await _respository.Get(request.Id);

        await _respository.Remove(suplier);

        return await Result<bool>.SuccessAsync("Fornecedor removido!");
    }
}