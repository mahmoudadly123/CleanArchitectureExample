using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.Abstract;

public interface ICommand:IRequest<Result>
{
    
}
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}