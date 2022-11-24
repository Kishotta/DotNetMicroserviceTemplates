using Microservice.Domain.Entities;

namespace Microservice.Application.Features.Cars.Commands.PatchCar;

public sealed record PatchCarCommand(Guid Id, Car car) : ICommand<CarResponse>;