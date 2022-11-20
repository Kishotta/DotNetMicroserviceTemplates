namespace Microservice.Application.Abstractions;

internal interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
