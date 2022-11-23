namespace Microservice.Application.Abstractions.Messaging;

internal interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
