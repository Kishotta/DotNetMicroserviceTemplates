using Microservice.Domain.Repositories;

namespace Microservice.Application.Features.Cars.Queries.GetCarById;

internal sealed class GetCarByIdQueryHandler : IQueryHandler<GetCarByIdQuery, CarResponse>
{
    private readonly ICarRepository _carRepository;
    
    public GetCarByIdQueryHandler (ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Result<CarResponse>> Handle (GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync (request.CarId, cancellationToken);

        if (car is null)
        {
            return Result.Failure<CarResponse> (new Error (
                                                    "Car.NotFound", 
                                                    $"The car with Id {request.CarId} was not found."));
        }

        var response = new CarResponse (car.Id, car.Year, car.Make, car.Model);

        return response;
    }
}