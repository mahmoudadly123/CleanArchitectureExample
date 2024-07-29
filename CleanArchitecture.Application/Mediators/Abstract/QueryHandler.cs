using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.Abstract;


public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : class
{

}

/// <summary>
/// Extended IRequestHandler For Mediator to support AutoMapper (Object Mapping) and DbContext as UnitOfWork
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class QueryHandler<TQuery, TResponse> : BaseHandler<TQuery,TResponse>,
    IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : class
{

    #region Constructors

    protected QueryHandler(IMapper autoMapper) : base(autoMapper)
    {
    }

    protected QueryHandler(IMapper autoMapper, INotificationPublisher notificationPublisher) : base(autoMapper, notificationPublisher)
    {
    }

    protected QueryHandler(IUnitOfWork unitOfWork, IMapper autoMapper) : base(unitOfWork, autoMapper)
    {
    }

    protected QueryHandler(IUnitOfWork unitOfWork, IMapper autoMapper, INotificationPublisher notificationPublisher) : base(unitOfWork, autoMapper, notificationPublisher)
    {
    }

    #endregion

}

