using MediatR;
using Microservice.Domain.Shared;

namespace Microservice.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
