using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.Abstract;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}