using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.Abstract;

public abstract class BaseHandler<TRequest, TResponse>
{
    #region Properties

    /// <summary>
    /// DbContext as Unit Of Work
    /// </summary>
    protected IUnitOfWork UnitOfWork { get; set; }

    /// <summary>
    /// Auto Mapper For Object Mapping like dto to other class
    /// </summary>
    protected IMapper AutoMapper { get; set; }

    /// <summary>
    /// Publisher For Notification to Handle by its handlers
    /// </summary>
    protected INotificationPublisher NotificationPublisher { get; set; }

    #endregion

    #region Constructors

    protected BaseHandler(IMapper autoMapper)
    {
        UnitOfWork = null!;
        AutoMapper = autoMapper;
        NotificationPublisher = null!;

    }
    protected BaseHandler(IMapper autoMapper, INotificationPublisher notificationPublisher)
    {
        UnitOfWork = null!;
        AutoMapper = autoMapper;
        NotificationPublisher = notificationPublisher;
    }

    protected BaseHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
    {
        UnitOfWork = unitOfWork;
        AutoMapper = autoMapper;
        NotificationPublisher = null!;

    }

    protected BaseHandler(IUnitOfWork unitOfWork, IMapper autoMapper, INotificationPublisher notificationPublisher)
    {
        UnitOfWork = unitOfWork;
        AutoMapper = autoMapper;
        NotificationPublisher = notificationPublisher;
    }


    #endregion

    #region Methods

    public abstract Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

    #endregion
}