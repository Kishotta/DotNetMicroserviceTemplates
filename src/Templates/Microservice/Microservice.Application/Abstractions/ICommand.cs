namespace Microservice.Application.Abstractions;

internal interface ICommand : IRequest<Result> { }

internal interface ICommand<TResponse> : IRequest<Result<TResponse>> { }