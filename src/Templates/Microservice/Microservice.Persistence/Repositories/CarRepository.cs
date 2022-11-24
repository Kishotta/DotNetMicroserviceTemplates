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

    public void Add (Car car)
    {
        _dbContext.Set<Car> ().Add (car);
    }
}