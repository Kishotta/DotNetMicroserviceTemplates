using Microservice.Domain.Entities;

namespace Microservice.Domain.Repositories;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync (Guid id, CancellationToken cancellationToken = default);
    void Add (Car car);
}