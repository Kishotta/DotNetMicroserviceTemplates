namespace Microservice.Application.Features.Cars;

public sealed record CarResponse(Guid Id, int Year, string Make, string Model);