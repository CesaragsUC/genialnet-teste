using Application.Interfaces;
using Domain.Common;

namespace Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly GenialnetDbContext _dbContext;
    private bool disposed;

    public UnitOfWork(GenialnetDbContext context)
    {
        _dbContext = context;
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        var repositoryType = typeof(GenericRepository<>);

        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

        return (IGenericRepository<T>)repositoryInstance;
    }

    public Task Rollback()
    {
        _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }

    public async Task<bool> Save(CancellationToken cancellationToken)
    {
       return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
