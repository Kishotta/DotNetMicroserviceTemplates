using Microservice.Domain.Repositories;

namespace Microservice.Application.Features.Cars.Queries.GetCars;

internal sealed class GetCarsQueryHandler : IQueryHandler<GetCarsQuery, IEnumerable<CarResponse>>
{
    private readonly ICarRepository _carRepository;

    public GetCarsQueryHandler (ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Result<IEnumerable<CarResponse>>> Handle (GetCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAsync (cancellationToken);

        return cars.Select (car => new CarResponse(car.Id, car.Year, car.Make, car.Model)).ToList ();
    }
}