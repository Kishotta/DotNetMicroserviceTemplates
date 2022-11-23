namespace Microservice.Application.Abstractions.Messaging;

internal interface IQueryHandler <TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }