namespace Microservice.Application.Features.Cars.Queries.GetCarById;

public sealed record GetCarByIdQuery(Guid CarId) : IQuery<CarResponse>;