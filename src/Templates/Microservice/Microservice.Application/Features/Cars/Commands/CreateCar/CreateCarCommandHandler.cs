using Microservice.Application.Features.Cars.Queries.GetCarById;
using Microservice.Domain.Entities;
using Microservice.Domain.Repositories;

namespace Microservice.Application.Features.Cars.Commands.CreateCar;

internal sealed class CreateCarCommandHandler : ICommandHandler<CreateCarCommand, CarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork    _unitOfWork;

    public CreateCarCommandHandler (ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository   = carRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<CarResponse>> Handle (CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car (Guid.NewGuid (), request.Year, request.Make, request.Model);

        _carRepository.Add (car);

        await _unitOfWork.SaveChangesAsync (cancellationToken);

        return new CarResponse(car.Id, car.Year, car.Make, car.Model);
    }
}