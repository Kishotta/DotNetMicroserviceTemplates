namespace Microservice.Application.Features.Cars.Commands.RemoveCar;

public sealed record RemoveCarCommand(Guid CarId) : ICommand;