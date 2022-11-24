namespace Microservice.Application.Features.Cars.Queries.GetCars;

public sealed record GetCarsQuery() : IQuery<IEnumerable<CarResponse>>;