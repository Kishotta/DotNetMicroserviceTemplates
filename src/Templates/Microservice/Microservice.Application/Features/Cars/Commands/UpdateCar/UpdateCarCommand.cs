namespace Microservice.Application.Features.Cars.Commands.UpdateCar;

public sealed record UpdateCarCommand(Guid CarId, int Year, string Make, string Model) 
    : ICommand<CarResponse>;