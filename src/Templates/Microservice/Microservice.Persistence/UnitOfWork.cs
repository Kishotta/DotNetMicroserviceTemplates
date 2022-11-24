using Microservice.Domain.Repositories;

namespace Microservice.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _dbContext;
    
    public UnitOfWork (DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveChangesAsync (CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync (cancellationToken);
    }
}