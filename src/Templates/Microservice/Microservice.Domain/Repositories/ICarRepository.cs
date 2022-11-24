using Microservice.Domain.Entities;

namespace Microservice.Domain.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAsync (CancellationToken cancellationToken);
    Task<Car?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default);
    void Add (Car car);
}