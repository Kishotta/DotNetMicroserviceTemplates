using Microservice.Domain.Entities;
using Microservice.Domain.Repositories;

namespace Microservice.Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly DatabaseContext _dbContext;

    public CarRepository (DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Car>> GetAsync (CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Car> ()
                               .ToListAsync (cancellationToken);
    }

    public async Task<Car?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Car>()
                               .FirstOrDefaultAsync(car => car.Id == id, cancellationToken);
    }

    public void Add (Car car)
    {
        _dbContext.Set<Car> ()
                  .Add (car);
    }
}