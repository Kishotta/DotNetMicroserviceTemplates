namespace Microservice.Application.Features.Cars.Queries.GetCarById;

public sealed record CarResponse(Guid Id, int Year, string Make, string Model);