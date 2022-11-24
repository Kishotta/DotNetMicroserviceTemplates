using Microservice.Domain.Entities;
using Microservice.Domain.Repositories;

namespace Microservice.Application.Features.Cars.Commands.CreateCar;

public class CreateCarCommandHandler : ICommandHandler<CreateCarCommand, Guid>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork    _unitOfWork;

    public CreateCarCommandHandler (ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository   = carRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Guid>> Handle (CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car (Guid.NewGuid (), request.Year, request.Make, request.Model);

        _carRepository.Add (car);

        await _unitOfWork.SaveChangesAsync (cancellationToken);

        return car.Id;
    }
}