using Domain.Common;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<T> Repository<T>() where T : BaseEntity;

    Task<bool> Save(CancellationToken cancellationToken);

    Task Rollback();
}
