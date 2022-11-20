namespace Microservice.Application.Abstractions;

internal interface IQueryHandler <TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }