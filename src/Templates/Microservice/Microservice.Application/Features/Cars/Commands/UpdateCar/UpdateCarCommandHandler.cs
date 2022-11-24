using Microservice.Application.Features.Cars.Commands.CreateCar;
using Microservice.Domain.Entities;
using Microservice.Domain.Repositories;

namespace Microservice.Application.Features.Cars.Commands.UpdateCar;

internal sealed  class UpdateCarCommandHandler : ICommandHandler<UpdateCarCommand, CarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork    _unitOfWork;
    private readonly ISender        _sender;

    public UpdateCarCommandHandler (ICarRepository carRepository, IUnitOfWork unitOfWork, ISender sender)
    {
        _carRepository = carRepository;
        _unitOfWork    = unitOfWork;
        _sender   = sender;
    }

    public async Task<Result<CarResponse>> Handle (UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync (request.CarId, cancellationToken);

        if (car is null)
        {
            car = new Car (request.CarId, request.Year, request.Make, request.Model);
            
            _carRepository.Add (car);
        }
        else
        {
            car.Year = request.Year;
            car.Make = request.Make;
            car.Model = request.Model;
            
            _carRepository.Update (car);
        }
        
        await _unitOfWork.SaveChangesAsync (cancellationToken);

        return new CarResponse(car.Id, car.Year, car.Make, car.Model);
    }
}