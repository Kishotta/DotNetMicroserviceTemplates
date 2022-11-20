using MediatR;
using Microservice.Domain.Shared;

namespace Microservice.Application.Abstractions;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }