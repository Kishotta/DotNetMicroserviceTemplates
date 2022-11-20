using MediatR;
using Microservice.Domain.Shared;

namespace Microservice.Application.Abstractions;

public interface IQueryHandler <TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }