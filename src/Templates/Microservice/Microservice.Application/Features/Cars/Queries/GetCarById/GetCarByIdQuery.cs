namespace Microservice.Application.Features.Cars.Queries.GetCarById;

public record GetCarByIdQuery(Guid CarId) : IQuery<CarResponse>;