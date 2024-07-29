using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.Abstract;


public interface ICommandHandler<TCommand>:IRequestHandler<TCommand,Result> 
    where TCommand : ICommand
{

}

public interface ICommandHandler<TCommand,TResponse> : IRequestHandler<TCommand, Result<TResponse>> 
    where TCommand : ICommand<TResponse> 
    where TResponse : class
{

}

/// <summary>
/// Extended IRequestHandler For Mediator to support AutoMapper (Object Mapping) and DbContext as UnitOfWork
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class CommandHandler<TRequest, TResponse> : BaseHandler<TRequest, TResponse>,
    ICommandHandler<TRequest,TResponse> 
    where TRequest : ICommand<TResponse> 
    where TResponse: class
{
    #region Constructors

    protected CommandHandler(IMapper autoMapper) : base(autoMapper)
    {
    }

    protected CommandHandler(IMapper autoMapper, INotificationPublisher notificationPublisher) : base(autoMapper, notificationPublisher)
    {
    }

    protected CommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper) : base(unitOfWork, autoMapper)
    {
    }

    protected CommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper, INotificationPublisher notificationPublisher) : base(unitOfWork, autoMapper, notificationPublisher)
    {
    }

    #endregion
}

