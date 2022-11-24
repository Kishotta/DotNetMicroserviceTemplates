using Microservice.Domain.Entities;

namespace Microservice.Domain.Repositories;

public interface ICarRepository
{
    void Add (Car car);
}