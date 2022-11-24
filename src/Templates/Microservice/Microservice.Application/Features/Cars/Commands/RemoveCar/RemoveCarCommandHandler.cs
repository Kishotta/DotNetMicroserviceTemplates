using Microservice.Domain.Repositories;

namespace Microservice.Application.Features.Cars.Commands.RemoveCar;

internal sealed class RemoveCarCommandHandler : ICommandHandler<RemoveCarCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork    _unitOfWork;

    public RemoveCarCommandHandler (ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork    = unitOfWork;
    }

    public async Task<Result> Handle (RemoveCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync (request.CarId, cancellationToken);

        if (car is null)
        {
            return Result.Failure (new Error (
                                       "Car.NotFound",
                                       $"The car with Id {request.CarId} was not found."));
        }
        
        _carRepository.Remove (car);

        await _unitOfWork.SaveChangesAsync (cancellationToken);

        return Result.Success ();
    }
}