namespace Microservice.Application.Features.Cars.Commands.CreateCar;

public sealed record CreateCarCommand(int Year, string Make, string Model) 
    : ICommand<CarResponse>;